using BookstoreAPI.Data;
using BookstoreAPI.DTOs;
using BookstoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly BookstoreContext _context;

        public GenreService(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
        {
            return await _context.Genres
                .Select(g => new GenreDto
                {
                    genre_id = g.genre_id,
                    genre_name = g.genre_name,
                    description = g.description
                })
                .ToListAsync();
        }

        public async Task<GenreDto> GetGenreByIdAsync(int genre_id)
        {
            var genre = await _context.Genres.FindAsync(genre_id);
            if (genre == null) return null;

            return new GenreDto
            {
                genre_id = genre.genre_id,
                genre_name = genre.genre_name,
                description = genre.description
            };
        }

        public async Task<GenreDto> CreateGenreAsync(GenreDto genreDto)
        {
            var genre = new Genre
            {
                genre_name = genreDto.genre_name,
                description = genreDto.description
            };

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            genreDto.genre_id = genre.genre_id;
            return genreDto;
        }

        public async Task UpdateGenreAsync(GenreDto genreDto)
        {
            var genre = await _context.Genres.FindAsync(genreDto.genre_id);
            if (genre == null) throw new KeyNotFoundException("Genre not found");

            genre.genre_name = genreDto.genre_name;
            genre.description = genreDto.description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(int genre_id)
        {
            var genre = await _context.Genres.FindAsync(genre_id);
            if (genre == null) throw new KeyNotFoundException("Genre not found");

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}
