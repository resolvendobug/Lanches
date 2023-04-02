using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lanches.Areas.Admin.Views.AdminPedidos
{
    public class PedidoLanches : PageModel
    {
        private readonly ILogger<PedidoLanches> _logger;

        public PedidoLanches(ILogger<PedidoLanches> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}