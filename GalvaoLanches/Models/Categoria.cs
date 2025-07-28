using System.ComponentModel.DataAnnotations.Schema;

namespace GalvaoLanches.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }
        
        public List<Lanche> Lanches { get; set; }

    }
}
