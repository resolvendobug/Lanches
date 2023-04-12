using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lanches.Areas.Admin.Controllers
{
    [Route("[controller]")]
    public class AdminGraficoController : Controller
    {

        private readonly GraficoVendasService _graficoVendasService;

        public AdminGraficoController(GraficoVendasService graficoVendasService)
        {
            _graficoVendasService = graficoVendasService;
        }

        public JsonResult VendasLanches(int dias)
        {
            var lanchesVendasTotais = _graficoVendasService.GetVendasLanches(dias);
            return Json(lanchesVendasTotais);
        }

        public IActionResult Index(int dias)
        {
            return View();
        }

        public IActionResult VendasMensal(int dias)
        {
            return View();
        }
        
        public IActionResult VendasSemanal(int dias)
        {
            return View();
        }

    }
}