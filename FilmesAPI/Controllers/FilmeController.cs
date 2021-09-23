using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> _filmes { get; set; } = new List<Filme>();

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            if (String.IsNullOrWhiteSpace(filme.Titulo) || String.IsNullOrWhiteSpace(filme.Diretor) || String.IsNullOrWhiteSpace(filme.Genero) || String.IsNullOrWhiteSpace(filme.Duracao.ToString()))
                return BadRequest();

            _filmes.Add(filme);

            return Ok();
        }

        [HttpGet]
        public IActionResult RetornaFilmes()
        {
            return Ok(_filmes);
        }
    }
}
