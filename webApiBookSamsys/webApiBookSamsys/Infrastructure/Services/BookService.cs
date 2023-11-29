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
using AutoMapper;

namespace webApiBookSamsys.Infrastructure.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(BookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<MessangingHelper<List<BookDTO>>> GetBooks()
        {
            string errorMessage = "Não existe livros na lista";
            string okMessage = "Retorno da lista de livros bem sucedida";
            MessangingHelper<List<BookDTO>> response = new();
            try
            {
                var livrosExistem = await _bookRepository.GetBooksAsync();  
                if (livrosExistem == null)
                {
                   response.Message = errorMessage;
                    return response;
                }
                var livrosDTO = _mapper.Map<List<BookDTO>>(livrosExistem);
                response.Message = okMessage;
                response.Obj = livrosDTO;
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
                if (isbn.Length != 13)
                {
                    response.Message = badRequest;
                    return response;
                }
                var livroExiste = await _bookRepository.GetBookByIsbn(isbn);   
                if (livroExiste == null)
                {
                    response.Message = errorMessage;
                    return response;
                }
                var bookDetailsDTO = _mapper.Map<BookDTO>(livroExiste);
                response.Message = okMessage;
                response.Obj = bookDetailsDTO;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MessangingHelper<BookDTO>> PostBookAsync([FromBody] BookDTO bookDTO) 
        {
            string errorMessage = "Livro já existe";
            string badRequest = "Preencha os campos corretamente";
            string okMessage = "Livro criado com sucesso";
            MessangingHelper<BookDTO> response = new();
            try
            {
                var livroExiste = await _bookRepository.GetBookByIsbn(bookDTO.ISBN);
                if(livroExiste == null)
                {
                    if (bookDTO.ISBN.Length == 13 && bookDTO.Name.Length >1 && bookDTO.Price > 0)
                    {
                        var mappedBook = _mapper.Map<Book>(bookDTO);        
                        var bookAdd = await _bookRepository.PostNewBook(mappedBook);   
                        response.Message = okMessage;
                        response.Obj = _mapper.Map<BookDTO>(bookAdd);
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

               var livro = await _bookRepository.GetBookByIsbn(isbn);

               if (livro != null )
               {
                    var removerLivro = await _bookRepository.RemoveOneBook(isbn);
                    // Map Book entity to BookDTO
                    var mappedBook = _mapper.Map<BookDTO>(removerLivro);
                    response.Message = okMessage;
                    response.Obj = mappedBook;
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
               var livroExiste = await _bookRepository.GetBookByIsbn(isbn);
               if (livroExiste == null)
               {
                    response.Message = notFound;
                    return response;
                }
               else
               {
                   if(book.ISBN != livroExiste.ISBN || book.Name.Length <=1 || book.Price <= 0)
                   {
                        response.Message = errorMessageValues;
                        return response; 
                   }

                    var mappedBook = _mapper.Map<Book>(book);
                    var livroEditado = await _bookRepository.EditOneBook(isbn, mappedBook);   

                    response.Message = okMessage;
                    response.Obj = _mapper.Map<BookDTO>(livroEditado);
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
