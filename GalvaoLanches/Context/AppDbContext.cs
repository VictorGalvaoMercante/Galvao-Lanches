using GalvaoLanches.Models;
using Microsoft.EntityFrameworkCore;

namespace GalvaoLanches.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; } //Criação da tabela Categoria no banco de dados
        public DbSet<Lanche> Lanches { get; set; } //Criação da tabela Lanche no banco de dados
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    }
}
