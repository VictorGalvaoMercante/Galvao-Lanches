using GalvaoLanches.Context;
using Microsoft.EntityFrameworkCore;

namespace GalvaoLanches.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _appDbContext;
        public CarrinhoCompra(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string carrinhoCompraId = session.GetString("CarrinhoCompraId") ?? Guid.NewGuid().ToString();
            session.SetString("CarrinhoCompraId", carrinhoCompraId);

            return new CarrinhoCompra(context) { CarrinhoCompraId = carrinhoCompraId };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _appDbContext.CarrinhoCompraItens.SingleOrDefault(
                c => c.Lanche.LancheId == lanche.LancheId && c.CarrinhoCompraId == CarrinhoCompraId);
            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _appDbContext.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _appDbContext.SaveChanges();
        }
        public void RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _appDbContext.CarrinhoCompraItens.SingleOrDefault(
                c => c.Lanche.LancheId == lanche.LancheId && c.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    
                }
                else
                {
                    _appDbContext.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _appDbContext.SaveChanges();
        }
        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItens ?? (CarrinhoCompraItens = _appDbContext.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(c => c.Lanche)
                .ToList());
        }
        public void LimparCarrinho()
        {
            var carrinhoCompraItens = _appDbContext.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId);
            _appDbContext.CarrinhoCompraItens.RemoveRange(carrinhoCompraItens);
            _appDbContext.SaveChanges();
        }
        public decimal GetCarrinhoCompraTotal()
        {
            return _appDbContext.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
        }
        

    }
}
