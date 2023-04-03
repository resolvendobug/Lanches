using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Lanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminImagensController(IOptions<ConfigurationImagens> myConfiguration, IWebHostEnvironment hostingEnvironment)
        {
            _myConfig = myConfiguration.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if(files == null || files.Count == 0)
            {
               ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if(files.Count > 10)
            {
                ViewData["Erro"] = "Error: Limite de 10 arquivos por vez";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();
            
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach(var formFile in files)
            {
                if(formFile.Length > 0)
                {
                    if(formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".png") || formFile.FileName.Contains(".gif"))
                    {
                        var fileNameWithPath = string.Concat(filePath,"\\", formFile.FileName);

                        filePathsName.Add(fileNameWithPath);

                        using(var stream = new FileStream(Path.Combine(filePath, formFile.FileName), FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                    else
                    {
                        ViewData["Erro"] = "Error: Arquivo(s) não suportado(s)";
                        return View(ViewData);
                    }
                 
                }
            }

            ViewData["Resultado"] = $"{files.Count} arquivo(s) carregado(s) com sucesso! "+
                                    $" Tamanho total: {size} bytes";

            ViewBag.Arquivos = filePathsName;

            return View(ViewData);
        }

        public IActionResult GetImagens()
        {
            FileManagerModel model = new FileManagerModel();
            var userImagensPath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            DirectoryInfo dir = new DirectoryInfo(userImagensPath);

            FileInfo[] files = dir.GetFiles();

            model.PathImagesProduto = _myConfig.NomePastaImagensProdutos;

            if(files.Length == 0)
            {
                ViewData["Erro"] = $"Error: Nenhum arquivo encontrado na pasta {userImagensPath}";
            }
           
           model.Files = files;

            return View(model);
        }
    }
}