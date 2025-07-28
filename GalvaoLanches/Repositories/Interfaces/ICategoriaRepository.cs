using GalvaoLanches.Models;

namespace GalvaoLanches.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> categoria { get; }

    }
}
