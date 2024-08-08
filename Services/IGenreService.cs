using BookstoreAPI.DTOs;

namespace BookstoreAPI.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GetAllGenresAsync();
        Task<GenreDto> GetGenreByIdAsync(int genre_id);
        Task<GenreDto> CreateGenreAsync(GenreDto genreDto);
        Task UpdateGenreAsync(GenreDto genreDto);
        Task DeleteGenreAsync(int genre_id);
    }
}
