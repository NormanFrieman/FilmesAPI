using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> _filmes { get; set; } = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            filme.Id = id;
            _filmes.Add(filme);
            id++;

            return CreatedAtAction(nameof(RetornaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RetornaFilmes()
        {
            return Ok(_filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RetornaFilmePorId(int id)
        {
            var filme = _filmes.FirstOrDefault(x => x.Id == id);

            if (filme == null)
                return NotFound();
            
            return Ok(filme);
        }
    }
}
