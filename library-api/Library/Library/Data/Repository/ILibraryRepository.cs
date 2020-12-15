using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public interface ILibraryRepository
    {
        Task<bool> SaveChanges();
        Task<BookEntity> GetBook(int id);
        void UpdateBook(BookEntity book);
        void CreateBook(BookEntity book);
        Task DeleteBook(int id);
        Task<IEnumerable<BookEntity>> GetAllBooks();

    }
}
