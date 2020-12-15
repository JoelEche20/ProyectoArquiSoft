using Library.Data.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private LibraryDbContext _libraryDbContext;
        private List<Book> _books = new List<Book>();
        public LibraryRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public void CreateBook(BookEntity book)
        {
            _libraryDbContext.Books.Add(book);
        }

        public async Task DeleteBook(int id)
        {
            var bookToDelete = await _libraryDbContext.Books.SingleAsync(a => a.Id == id);
            _libraryDbContext.Books.Remove(bookToDelete);
        }

        public async Task<IEnumerable<BookEntity>> GetAllBooks()
        {
            IEnumerable<BookEntity> books = _libraryDbContext.Books;
            return books;
        }

        public async Task<BookEntity> GetBook(int id)
        {
            IQueryable<BookEntity> query = _libraryDbContext.Books;
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _libraryDbContext.SaveChangesAsync()) > 0;
        }

        public  void UpdateBook(BookEntity book)
        {
            _libraryDbContext.Books.Update(book);
        }
    }
}
