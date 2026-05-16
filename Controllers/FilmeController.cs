using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase 
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost] // Realiza a inserção de um recurso no sistema
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmePorId),
            new { id = filme.Id },
            filme);
    }

    [HttpGet] // Realiza a leitura de um recurso no sistema
    public IEnumerable<Filme> RecuperarFilmes([FromQuery]int skip = 0, [FromQuery]int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme =  filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound(); // Retorna um código de status HTTP 404 (Not Found) se o filme não for encontrado
        return Ok(filme); // Retorna um código de status HTTP 200 (OK) junto com o filme encontrado
    }
}
