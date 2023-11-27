using Microsoft.AspNetCore.Mvc;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.MessagingHelper;
using webApiBookSamsys.Infrastructure.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Net.Mime;
using Azure;

namespace webApiBookSamsys.Infrastructure.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService (BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
       
        public async Task<ActionResult<Book>>GetBooks()    
        {
           // string errorMessage = "Ocorreu um erro enquanto era buscado o livro";
            
            try
            {
                var livros = await _bookRepository.GetBooksAsync();
                if (livros == null)
                {
                    return new BadRequestResult();
                }
                return new OkObjectResult(livros);
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<ActionResult<Book>> GetBookByIsbn(string isbn)
        {
            var result = new List<Book>();
            try
           {
               var livro = await _bookRepository.GetBookByIsbn(isbn);
               if (livro == null)
               {
                    return new BadRequestResult();
               }

               if (isbn.Length != 13)
                {
                    return new BadRequestResult();
                }

                return new OkObjectResult(livro);
            }
           catch (Exception)
           {
                throw;
           }
        }
         

        public async Task<ActionResult<Book>> PostBookAsync([FromBody] Book book)
        {
            
            try
            {
                if (book.ISBN.Length != 13 || book.Name == null || book.Price < 0)
                {
                    return new BadRequestResult();
                }
                var responsta = await _bookRepository.PostNewBook(book);
                return new OkObjectResult(responsta);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        public List<Book> BadRequestException(string v)
        {
            throw new NotImplementedException();
        }

        public List<Book> Ok(string v)
        {
            throw new NotImplementedException();
        }

        public List<Book> StatusCode(int v1, string v2)
        {
            throw new NotImplementedException();
        }

        public List<Book> NotFound(string v)
        {
            throw new NotImplementedException();
        }
        */
    }
}
