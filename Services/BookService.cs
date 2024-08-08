// File: Services/BookService.cs
using BookstoreAPI.DTOs;
using BookstoreAPI.Models;
using BookstoreAPI.Repositories;

namespace BookstoreAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return books.Select(MapToDto);
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return book == null ? null : MapToDto(book);
        }

        public async Task<BookDto> CreateBookAsync(BookDto bookDto)
        {
            var book = new Book
            {
                title = bookDto.title,
                author_id = bookDto.author_id,
                genre_id = bookDto.genre_id,
                isbn = bookDto.isbn,
                price = bookDto.price
            };
            var createdBook = await _bookRepository.CreateBookAsync(book);
            return MapToDto(createdBook);
        }

        public async Task<BookDto> UpdateBookAsync(BookDto bookDto)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(bookDto.book_id);
            if (existingBook == null)
                return null;

            existingBook.title = bookDto.title;
            existingBook.author_id = bookDto.author_id;
            existingBook.genre_id = bookDto.genre_id;
            existingBook.isbn = bookDto.isbn;
            existingBook.price = bookDto.price;

            var updatedBook = await _bookRepository.UpdateBookAsync(existingBook);
            return MapToDto(updatedBook);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }

        private BookDto MapToDto(Book book)
        {
            return new BookDto
            {
                book_id = book.book_id,
                title = book.title,
                author_id = book.author_id,
                author_name = book.Author?.name ?? "Unknown",
                genre_id = book.genre_id,
                genre_name = book.Genre?.genre_name ?? "Unknown",
                isbn = book.isbn,
                price = book.price
            };
        }
    }
}