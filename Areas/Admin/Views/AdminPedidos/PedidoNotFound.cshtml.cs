using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lanches.Areas.Admin.Views.AdminPedidos
{
    public class PedidoNotFound : PageModel
    {
        private readonly ILogger<PedidoNotFound> _logger;

        public PedidoNotFound(ILogger<PedidoNotFound> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}