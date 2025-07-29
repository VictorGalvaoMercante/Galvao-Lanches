using GalvaoLanches.Repositories.Interfaces;
using GalvaoLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GalvaoLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria A";

            return View (lanchesListViewModel);
        }
    }
}
