using GalvaoLanches.Repositories.Interfaces;
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
            ViewData["Titulo"] = "Todos os lanches";
         

            var lanches = _lancheRepository.lanches;
        

            return View(lanches);
        }
    }
}
