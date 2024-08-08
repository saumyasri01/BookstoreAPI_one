using BookstoreAPI.Data;
using BookstoreAPI.DTOs;
using BookstoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookstoreContext _context;

        public AuthorService(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            return await _context.Authors
                .Select(a => new AuthorDto
                {
                    author_id = a.author_id,
                    name = a.name,
                    biography = a.biography,
                    birth_date = a.birth_date
                })
                .ToListAsync();
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int author_id)
        {
            var author = await _context.Authors.FindAsync(author_id);
            if (author == null) return null;

            return new AuthorDto
            {
                author_id = author.author_id,
                name = author.name,
                biography = author.biography,
                birth_date = author.birth_date
            };
        }

        public async Task<AuthorDto> CreateAuthorAsync(AuthorDto authorDto)
        {
            var author = new Author
            {
                name = authorDto.name,
                biography = authorDto.biography,
                birth_date = authorDto.birth_date
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            authorDto.author_id = author.author_id;
            return authorDto;
        }

        public async Task UpdateAuthorAsync(AuthorDto authorDto)
        {
            var author = await _context.Authors.FindAsync(authorDto.author_id);
            if (author == null) throw new KeyNotFoundException("Author not found");

            author.name = authorDto.name;
            author.biography = authorDto.biography;
            author.birth_date = authorDto.birth_date;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int author_id)
        {
            var author = await _context.Authors.FindAsync(author_id);
            if (author == null) throw new KeyNotFoundException("Author not found");

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
