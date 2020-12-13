using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;
using Library.Services.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            try
            {
                var books = await _booksService.GetAllBooks();
                return Ok(books);
            }
            catch (Exception)
            {

                throw new Exception("there where and error with the DB");
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                var book = await this._booksService.GetBook(id);
                return Ok(book);
            }
            catch (Exception)
            {
                throw new Exception("there where and error with the DB");
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                return Ok(await this._booksService.UpdateBook(id, book));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postedBook = await this._booksService.CreateBook(book);
            return Ok(postedBook);
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<bool>> DeleteBook(int id, int categoryId)
        {
            try
            {
                return Ok(await this._booksService.DeleteBook(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }
    }
}
