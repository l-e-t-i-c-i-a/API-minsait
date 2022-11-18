using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers
{
    public class LivroController : Controller
    {
        private readonly BibliotecaContext _context;

        public LivroController(BibliotecaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var livros = _context.Livros.ToList();
            return View(livros);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(livro);
        }
        
        public IActionResult Editar(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro == null)
                return RedirectToAction(nameof(Index));

            return View(livro);
        }

        [HttpPost]
        public IActionResult Editar(Livro livro)
        {
            var livroBanco = _context.Livros.Find(livro.Id);

            livroBanco.Titulo = livro.Titulo;
            livroBanco.Autor = livro.Autor;
            livroBanco.Genero = livro.Genero;
            livroBanco.Lido = livro.Lido;

            _context.Livros.Update(livroBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro == null)
                return RedirectToAction(nameof(Index));

            return View(livro);
        }

    }
}
