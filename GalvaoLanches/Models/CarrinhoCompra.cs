namespace GalvaoLanches.Models
{
    public class CarrinhoCompra
    {
        public int CarrinhoCompraId { get; set; }
        public IEnumerable<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
    }
}
