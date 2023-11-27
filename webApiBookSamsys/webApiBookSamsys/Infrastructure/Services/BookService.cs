using Microsoft.AspNetCore.Mvc;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.MessagingHelper;
using webApiBookSamsys.Infrastructure.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace webApiBookSamsys.Infrastructure.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService (BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>>GetBooks()    
        {
           // string errorMessage = "Ocorreu um erro enquanto era buscado o livro";
            
            try
            {
                var livros = await _bookRepository.GetBooksAsync();
                if (livros == null)
                {
                    return Ok("Não existe livro na lista");
                }
                return livros;
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno.");
            }

        }

        public async Task<List<Book>> GetBookByIsbn(string isbn)
        {
           try
           {
               var livro = await _bookRepository.GetBookByIsbn(isbn);
               if (livro == null)
               {
                   return NotFound("Não existe o livro a ser pesquisado");
               }

               if (isbn.Length != 13)
                {
                    return BadRequestException("Quantidade de caracteres não correspondem ao pedido");
                }

               return livro;
           }
           catch (Exception)
           {
               return StatusCode(500, "Ocorreu um erro interno.");
           }
        }

        public async Task<List<Book>> PostBookAsync([FromBody] Book book) 
        {
            try
            {
                if (book.ISBN.Length != 13 || book.Name == null || book.Price < 0)
                {
                    return BadRequestException("Os campos precisam ser escritos de forma correta");
                }
                var responsta = await _bookRepository.PostNewBook(book);
                return Ok("Livro adicionado com sucesso");
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }


        private List<Book> BadRequestException(string v)
        {
            throw new NotImplementedException();
        }

        private List<Book> Ok(string v)
        {
            throw new NotImplementedException();
        }

        private List<Book> StatusCode(int v1, string v2)
        {
            throw new NotImplementedException();
        }

        private List<Book> NotFound(string v)
        {
            throw new NotImplementedException();
        }






    }
}
