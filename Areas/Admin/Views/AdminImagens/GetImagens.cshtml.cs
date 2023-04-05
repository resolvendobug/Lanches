using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lanches.Areas.Admin.Views.AdminImagens
{
    public class GetImagens : PageModel
    {
        private readonly ILogger<GetImagens> _logger;

        public GetImagens(ILogger<GetImagens> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}