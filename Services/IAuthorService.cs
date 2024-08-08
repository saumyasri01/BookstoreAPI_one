using BookstoreAPI.DTOs;

namespace BookstoreAPI.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto> GetAuthorByIdAsync(int author_id);
        Task<AuthorDto> CreateAuthorAsync(AuthorDto authorDto);
        Task UpdateAuthorAsync(AuthorDto authorDto);
        Task DeleteAuthorAsync(int author_id);
    }
}
