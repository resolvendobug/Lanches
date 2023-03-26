using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Models;
using Lanches.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lanches.ViewModels;

namespace Lanches.Controllers
{

    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(categoria)){
                lanches = _lancheRepository.Lanches.OrderBy(l => l.Id);
                categoriaAtual = "Todos os lanches";
            }else {
                
                lanches = _lancheRepository.Lanches.Where(l => l.Categoria.Nome.Equals(categoria)).OrderBy(l => l.Nome);
                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.Id == id);
            if(lanche == null){
                return NotFound();
            }
            return View(lanche);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.Id);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(l => l.Nome.ToLower().Contains(searchString.ToLower()));

                if(lanches.Any()){
                    categoriaAtual = "Lanches";
                }else{
                    categoriaAtual = "Nenhum lanche encontrado";
                }
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel 
            { 
                Lanches = lanches, 
                CategoriaAtual = categoriaAtual
            });
        }
    }
}