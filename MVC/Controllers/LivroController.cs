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
        
    }
}
