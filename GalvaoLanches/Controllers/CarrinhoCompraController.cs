﻿using Microsoft.AspNetCore.Mvc;

namespace GalvaoLanches.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
