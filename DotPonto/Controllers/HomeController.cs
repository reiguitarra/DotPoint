using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotPonto.Models;
using DotPonto.Services;

namespace DotPonto.Controllers
{
    public class HomeController : Controller
    {
        //  private readonly ILogger<HomeController> _logger;
        private readonly EmpresaService _empresaService;
        private readonly LotacaoService _lotacaoService;
        private readonly UsuarioService _usuarioService;

        public HomeController(EmpresaService empresaService, LotacaoService lotacaoService, UsuarioService usuarioService)
        {
            _empresaService = empresaService;
            _lotacaoService = lotacaoService;
            _usuarioService = usuarioService;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index()
        {
            var emp = await _empresaService.FindAllAsync();
            var lot = await _lotacaoService.FindAllAsync();
            var usu = await _usuarioService.FindAllAsync();

            ViewData["QtdEmp"] = emp.Count;
            ViewData["QtdLot"] = lot.Count;
            ViewData["QtdUsu"] = usu.Count;

            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
