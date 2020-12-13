using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services.Books
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBook(int id);
        Task<Book> UpdateBook(int id, Book book);
        Task<Book> CreateBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
