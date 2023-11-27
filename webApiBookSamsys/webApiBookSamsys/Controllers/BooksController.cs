using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.MessagingHelper;
using webApiBookSamsys.Infrastructure.Services;


namespace webApiBookSamsys.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        
        // GET: api/livros
        [HttpGet("livros")]
        public async Task<ActionResult<Book>> GetBooks()
        {
            return await _bookService.GetBooks();
        }
       
         // GET: api/livros/isbn
         [HttpGet("{isbn}")]

         public async Task<ActionResult<Book>> GetBook(string isbn)      
         {
             return await _bookService.GetBookByIsbn(isbn);
         }
         

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("livro")]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
              return await _bookService.PostBookAsync(book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{isbn}")]
        public async Task<ActionResult<Book>> DeleteBook(string isbn)    
        {
            return await _bookService.RemoveBook(isbn);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{isbn}")]
        public async Task<ActionResult> PutBook(string isbn, [FromBody] Book book) 
        {
            return await _bookService.EditBook(isbn, book);
        }
    }
}
