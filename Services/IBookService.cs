// File: Services/IBookService.cs
using BookstoreAPI.DTOs;

namespace BookstoreAPI.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int book_id);
        Task<BookDto> CreateBookAsync(BookDto bookDto);
        Task<BookDto> UpdateBookAsync(BookDto bookDto);
        Task<bool> DeleteBookAsync(int book_id);
    }
}

