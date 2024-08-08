
    using BookstoreAPI.Models;
    

    namespace BookstoreAPI.Repositories
    {
        public interface IAuthorRepository
        {
            Task<IEnumerable<Author>> GetAllAuthorsAsync();
            Task<Author> GetAuthorByIdAsync(int author_id);
            Task<Author> CreateAuthorAsync(Author author);
            Task UpdateAuthorAsync(Author author);
            Task DeleteAuthorAsync(int author_id);
        }
    }

