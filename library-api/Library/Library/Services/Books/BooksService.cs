using AutoMapper;
using Library.Data.Entities;
using Library.Data.Repository;
using Library.Models;
using Library.Services.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services.Books
{
    public class BooksService:IBooksService
    {
        private ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;
        private readonly ReviewService _reviewService;
        public BooksService(ILibraryRepository libraryRepository, IMapper mapper, ReviewService reviewService)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
            _reviewService = reviewService;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var booksEntity = await _libraryRepository.GetAllBooks();
            //var commentaries = _reviewService.GetReviews();
            var bookToReturn = _mapper.Map<IEnumerable<Book>>(booksEntity);
            return bookToReturn;
        }

        public async Task<Book> GetBook(int id)
        {
            var bookEntity = await _libraryRepository.GetBook(id);
            if (bookEntity == null)
                throw new Exception("there where and error with the DB");
            var bookToReturn = _mapper.Map<Book>(bookEntity);
            bookToReturn.ReviewList = await _reviewService.GetReviews(bookToReturn.Id);
            return bookToReturn;

        }

        public async Task<Book> UpdateBook(int id, Book book)
        {
            var validate = await _libraryRepository.GetBook(id);
            if (validate == null)
                throw new Exception();
            book.Id = id;
            var bookEntity = _mapper.Map<BookEntity>(book);
            _libraryRepository.UpdateBook(bookEntity);
            if (await _libraryRepository.SaveChanges())
            {
                return _mapper.Map<Book>(bookEntity);
            }
            throw new Exception("there were an error with DB");
            
        }

        public async Task<Book> CreateBook(Book book)
        {
            var bookEntity = _mapper.Map<BookEntity>(book);
            _libraryRepository.CreateBook(bookEntity);
            if(await _libraryRepository.SaveChanges())
            {
                return _mapper.Map<Book>(bookEntity);
            }
            throw new Exception("there where and error with the DB");
        }

        public async Task<bool> DeleteBook(int id)
        {
            await _libraryRepository.DeleteBook(id);
            if(await _libraryRepository.SaveChanges())
                return true;

            return false;
        }
    }
}
