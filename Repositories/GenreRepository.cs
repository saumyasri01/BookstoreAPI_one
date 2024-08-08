using BookstoreAPI.Data;
using BookstoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookstoreContext _context;

        public GenreRepository(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int genre_id)
        {
            return await _context.Genres.FindAsync(genre_id);
        }

        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(int genre_id)
        {
            var genre = await _context.Genres.FindAsync(genre_id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }
    }
}