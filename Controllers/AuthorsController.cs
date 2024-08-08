using Microsoft.AspNetCore.Mvc;
using BookstoreAPI.Services;
using BookstoreAPI.DTOs;


namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{author_id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int author_id)
        {
            var author = await _authorService.GetAuthorByIdAsync(author_id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorDto authorDto)
        {
            var createdAuthor = await _authorService.CreateAuthorAsync(authorDto);
            return CreatedAtAction(nameof(GetAuthor), new { author_id = createdAuthor.author_id }, createdAuthor);
        }

        [HttpPut("{author_id}")]
        public async Task<IActionResult> UpdateAuthor(int author_id, AuthorDto authorDto)
        {
            if (author_id != authorDto.author_id)
            {
                return BadRequest();
            }

            await _authorService.UpdateAuthorAsync(authorDto);
            return NoContent();
        }

        [HttpDelete("{author_id}")]
        public async Task<IActionResult> DeleteAuthor(int author_id)
        {
            await _authorService.DeleteAuthorAsync(author_id);
            return NoContent();
        }
    }
}
