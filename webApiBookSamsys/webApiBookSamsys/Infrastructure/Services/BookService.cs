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

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ActionResult<Book>> GetBooks()
        {
            // string errorMessage = "Ocorreu um erro enquanto era buscado o livro";

            try
            {
                var livros = await _bookRepository.GetBooksAsync();
                if (livros == null)
                {
                    return new NoContentResult();
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
            try
            {
                var livro = await _bookRepository.GetBookByIsbn(isbn);
                if (livro == null)
                {
                    return new NoContentResult();
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


        public async Task<ActionResult<Book>> RemoveBook(string isbn)
        {
            try
            {
                var livro = await _bookRepository.GetBookByIsbn(isbn);
                if (livro == null)
                {
                    return new NoContentResult();
                }
                else
                {
                    var removerLivro = await _bookRepository.RemoveOneBook(isbn);
                    return new OkObjectResult(removerLivro);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
