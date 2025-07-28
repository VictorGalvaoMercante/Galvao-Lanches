using GalvaoLanches.Context;
using GalvaoLanches.Models;
using GalvaoLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalvaoLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext contexto) 
        {
            _context = contexto;
        }
        public IEnumerable<Lanche> lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(l => l.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
