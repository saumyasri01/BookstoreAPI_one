using Microsoft.AspNetCore.Mvc;
using BookstoreAPI.Services;
using BookstoreAPI.DTOs;


namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{genre_id}")]
        public async Task<ActionResult<GenreDto>> GetGenre(int genre_id)
        {
            var genre = await _genreService.GetGenreByIdAsync(genre_id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<GenreDto>> CreateGenre(GenreDto genreDto)
        {
            var createdGenre = await _genreService.CreateGenreAsync(genreDto);
            return CreatedAtAction(nameof(GetGenre), new { genre_id = createdGenre.genre_id }, createdGenre);
        }

        [HttpPut("{genre_id}")]
        public async Task<IActionResult> UpdateGenre(int genre_id, GenreDto genreDto)
        {
            if (genre_id != genreDto.genre_id)
            {
                return BadRequest();
            }

            await _genreService.UpdateGenreAsync(genreDto);
            return NoContent();
        }

        [HttpDelete("{genre_id}")]
        public async Task<IActionResult> DeleteGenre(int genre_id)
        {
            await _genreService.DeleteGenreAsync(genre_id);
            return NoContent();
        }
    }
}