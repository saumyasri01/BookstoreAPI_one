using BookstoreAPI.Data;
using BookstoreAPI.Models;
using Microsoft.EntityFrameworkCore;

// File: Repositories/IBookRepository.cs


namespace BookstoreAPI.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int book_id);
        Task<Book> GetBookWithDetailsAsync(int book_id);  // New method
        Task<Book> CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int book_id);
    }
}

