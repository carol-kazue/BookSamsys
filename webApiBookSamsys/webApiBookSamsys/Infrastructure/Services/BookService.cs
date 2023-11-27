using Microsoft.AspNetCore.Mvc;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.MessagingHelper;
using webApiBookSamsys.Infrastructure.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Net.Mime;
using Azure;
using NuGet.LibraryModel;

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
                    return new NotFoundObjectResult("Não existe livro na lista");
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
                    return new NotFoundObjectResult("Livro Não existe");
                }

                if (isbn.Length != 13)
                {
                    return new NotFoundObjectResult("O ISBN precisa ter 13 caracteres");
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
                var livroExiste = await _bookRepository.GetBookByIsbn(book.ISBN);
                if(livroExiste.Value == null)
                {
                    if (book.ISBN.Length == 13 && book.Name != null && book.Price > 0)
                    {
                        var responsta = await _bookRepository.PostNewBook(book);
                        return new OkObjectResult(responsta);

                    }
                    return new BadRequestResult();
                }
                
                return new NotFoundObjectResult("Livro já existe");
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
                if (isbn.Length != 13)
                {
                    return new NotFoundObjectResult("O ISBN precisa ter 13 caracteres");
                }

                var livro = await _bookRepository.GetBookByIsbn(isbn);

                if (livro.Value != null )
                {
                    var removerLivro = await _bookRepository.RemoveOneBook(isbn);
                    return new OkObjectResult(removerLivro);
                }
                else
                {
                    return new NotFoundObjectResult("Livro não existe");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult> EditBook(string isbn, Book book)
        {
            try
            {

                if (isbn.Length != 13)
                {
                    return new NotFoundObjectResult("O ISBN precida ter 13 caracteres");
                }
                var livroExiste = await _bookRepository.GetBookByIsbn(isbn);
                if (livroExiste.Value == null)
                {
                    return new NotFoundObjectResult("Livro não existe");
                }
                else
                {
                    if(book.ISBN != livroExiste.Value.ISBN || book.Name == null || book.Price < 0)
                    {
                        return new NotFoundObjectResult("Os Campos precisam ser preenchidos corretamente");
                    }
                    var livroEditado = await _bookRepository.EditOneBook(isbn, book);
                    return new OkObjectResult(livroEditado);
                   
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
