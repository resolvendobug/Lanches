using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lanches.Areas.Admin.Views.AdminGrafico
{
    public class VendasSemanal : PageModel
    {
        private readonly ILogger<VendasSemanal> _logger;

        public VendasSemanal(ILogger<VendasSemanal> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}