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
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
          {
              return await _bookService.PostBookAsync(book);
          }

        /*

             // PUT: api/Books/5
             // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
             [HttpPut("{id}")]
             public async Task<IActionResult> PutBook(long id, Book book)
             {
                 if (id != book.id)
                 {
                     return BadRequest();
                 }

                 _context.Entry(book).State = EntityState.Modified;

                 try
                 {
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!BookExists(id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }

                 return NoContent();
             }




             private bool BookExists(long id)
             {
                 return (_context.Books?.Any(e => e.id == id)).GetValueOrDefault();
             }
             */
    }
}
