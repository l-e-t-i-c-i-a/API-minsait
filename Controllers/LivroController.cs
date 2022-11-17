using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Context;
using API.Entities;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public LivroController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Livro livro)
        {
            _context.Add(livro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = livro.Id }, livro);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        [HttpGet("ObterPorGenero")]
        public IActionResult ObterPorGenero(string genero)
        {
            var livros = _context.Livros.Where(x => x.Genero.Contains(genero));
            return Ok(livros);
        }
    }
}
