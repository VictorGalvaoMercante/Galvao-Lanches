using GalvaoLanches.Models;

namespace GalvaoLanches.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById(int lancheId);
    }
}
