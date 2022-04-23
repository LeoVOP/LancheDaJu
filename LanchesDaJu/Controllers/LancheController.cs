﻿using LanchesDaJu.Models;
using LanchesDaJu.Repositories.Intefaces;
using LanchesDaJu.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesDaJu.Controllers
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

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                //if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                //        .OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    lanches = _lancheRepository.Lanches
                //        .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                //        .OrderBy(l => l.Nome);
                //}

                lanches = _lancheRepository.Lanches
                         .Where(c => c.Categoria.CategoriaNome.Equals(categoria))
                         .OrderBy(l => l.Nome);
                 categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual                
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                          .Where(l => l.Nome.ToLower().Contains(searchString.ToLower()));

                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche encontrado";
            }
            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
