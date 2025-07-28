using GalvaoLanches.Context;
using GalvaoLanches.Models;
using GalvaoLanches.Repositories.Interfaces;

namespace GalvaoLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> categoria => _context.Categorias;

    }
}
