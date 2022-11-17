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

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livro)
        {
            var livroBanco = _context.Livros.Find(id);

            if (livroBanco == null)
                return NotFound();

            livroBanco.Titulo = livro.Titulo;
            livroBanco.Autor = livro.Autor;
            livroBanco.Genero = livro.Genero;
            livroBanco.Lido = livro.Lido;

            _context.Livros.Update(livroBanco);
            _context.SaveChanges();

            return Ok(livroBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var livroBanco = _context.Livros.Find(id);

            if (livroBanco == null)
                return NotFound();

            _context.Livros.Remove(livroBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
