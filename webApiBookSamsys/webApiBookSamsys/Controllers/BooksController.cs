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
using webApiBookSamsys.Infrastructure.Entities.DTOs;


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
        public async Task<MessangingHelper<List<BookDTO>>> GetBooks()
        {
            return await _bookService.GetBooks();
        }
       
         // GET: api/livros/isbn
         [HttpGet("{isbn}")]

         public async Task<MessangingHelper<BookDTO>> GetBook(string isbn)      
         {
             return await _bookService.GetBookByIsbn(isbn);
         }
         
        
        // POST: api/livro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("livro")]
        public async Task<MessangingHelper<BookDTO>> PostBook([FromBody] BookDTO book)
        {
              return await _bookService.PostBookAsync(book);
        }
        
        // DELETE: api/1235467895412
        [HttpDelete("{isbn}")]
        public async Task<MessangingHelper<BookDTO>> DeleteBook(string isbn)    
        {
            return await _bookService.RemoveBook(isbn);
        }
        
        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{isbn}")]
        public async Task<MessangingHelper<BookDTO>> PutBook(string isbn, [FromBody] BookDTO book) 
        {
            return await _bookService.EditBook(isbn, book);
        }
        
    }
}
