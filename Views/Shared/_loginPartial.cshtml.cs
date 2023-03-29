using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lanches.Views.Shared
{
    public class _loginPartial : PageModel
    {
        private readonly ILogger<_loginPartial> _logger;

        public _loginPartial(ILogger<_loginPartial> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}