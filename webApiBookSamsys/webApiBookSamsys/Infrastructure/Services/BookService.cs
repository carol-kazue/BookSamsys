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
using webApiBookSamsys.Infrastructure.Entities.DTOs;

namespace webApiBookSamsys.Infrastructure.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<MessangingHelper<List<BookDTO>>> GetBooks()
        {
            string errorMessage = "Não existe livros na lista";
            string okMessage = "Retorno da lista de livros bem sucedida";
            MessangingHelper<List<BookDTO>> response = new();
            try
            {
                var livros = await _bookRepository.GetBooksAsync();
                if (livros == null)
                {
                   response.Message = errorMessage;
                    return response;
                }
                response.Message = okMessage;
                response.Obj = livros;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<MessangingHelper<BookDTO>> GetBookByIsbn(string isbn)
        {
            string errorMessage = "Livro não existe";
            string badRequest = "O ISBN precisa ter 13 caracteres";
            string okMessage = "Livro encontrado";
            MessangingHelper<BookDTO> response = new();
            try
            {
                var livroExiste = await _bookRepository.BookExists(isbn);   
                if (livroExiste == null)
                {
                    response.Message = errorMessage;
                    return response;
                }
                if (isbn.Length != 13)
                {
                    response.Message = badRequest;
                    return response;
                }
                var livro = await _bookRepository.GetBookByIsbn(isbn);  
                response.Message = okMessage;
                response.Obj = livro;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MessangingHelper<BookDTO>> PostBookAsync([FromBody] BookDTO book)
        {
            string errorMessage = "Livro já existe";
            string badRequest = "Preencha os campos corretamente";
            string okMessage = "Livro criado com sucesso";
            MessangingHelper<BookDTO> response = new();
            try
            {
                var livroExiste = await _bookRepository.BookExists(book.ISBN);
                if(livroExiste == null)
                {
                    if (book.ISBN.Length == 13 && book.Name != null && book.Price > 0)
                    {
                        var newBook = await _bookRepository.PostNewBook(book);
                        response.Message = okMessage;
                        response.Obj = newBook;
                        response.Success = true;
                        return response;

                    }
                    response.Message = badRequest;
                    return response;
                }
                response.Message = errorMessage;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
       public async Task<MessangingHelper<BookDTO>> RemoveBook(string isbn)
       {
            string errorMessage = "O ISBN precisa ter 13 caracteres";
            string notFound = "Livro não existe";    
            string okMessage = "Livro removido com sucesso";
            MessangingHelper<BookDTO> response = new();
            try
           {
               if (isbn.Length != 13)
               {
                    response.Message = errorMessage;
                    return response;
                }

               var livro = await _bookRepository.BookExists(isbn);

               if (livro != null )
               {
                   var removerLivro = await _bookRepository.RemoveOneBook(isbn);
                    response.Message = okMessage;
                    response.Obj = removerLivro;
                    response.Success = true;
                    return response;
                }
               else
               {
                    response.Message = notFound;
                    return response;
                }

           }
           catch (Exception)
           {
               throw;
           }
       }
       
       public async Task<MessangingHelper<BookDTO>> EditBook(string isbn, BookDTO book)
       {
           try
           {
                string errorMessage = "O ISBN precisa ter 13 caracteres";
                string errorMessageValues = "Os Campos precisam ser preenchidos corretamente";
                string notFound = "Livro não existe";
                string okMessage = "Livro editado com sucesso";
                MessangingHelper<BookDTO> response = new();

                if (isbn.Length != 13)
               {
                    response.Message = errorMessage;
                    return response;
                }
               var livroExiste = await _bookRepository.BookExists(isbn);
               if (livroExiste == null)
               {
                    response.Message = notFound;
                    return response;
                }
               else
               {
                   if(book.ISBN != livroExiste.ISBN || book.Name == null || book.Price <= 0)
                   {
                        response.Message = errorMessageValues;
                        return response; 
                   }
                   var livroEditado = await _bookRepository.EditOneBook(isbn, book);
                    response.Message = okMessage;
                    response.Obj = livroEditado;
                    response.Success = true;
                    return response;
                }
           }
           catch (Exception)
           {
               throw;
           }

       }
      
    }
}
