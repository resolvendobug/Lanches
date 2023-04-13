using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lanches.Areas.Admin.Views.AdminGrafico
{
    public class VendasMensal : PageModel
    {
        private readonly ILogger<VendasMensal> _logger;

        public VendasMensal(ILogger<VendasMensal> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}