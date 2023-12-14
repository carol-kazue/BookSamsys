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
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public BookService(BookRepository bookRepository, AuthorRepository authorRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<MessangingHelper<List<BookDTO>>> GetBooks()
        {
            MessangingHelper<List<BookDTO>> response = new();
            try
            {
                var livrosExistem = await _bookRepository.GetBooksAsync();  
                if (livrosExistem == null)
                {
                   response.Message = "Não existe livros na lista";
                    return response;
                }
                var livrosDTO = _mapper.Map<List<BookDTO>>(livrosExistem);
                response.Message = "Retorno da lista de livros bem sucedida";
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
            MessangingHelper<BookDTO> response = new();

            try
            {
                if (isbn.Length != 13)
                {
                    response.Message = "O ISBN precisa ter 13 caracteres";
                    return response;
                }
                var livroExiste = await _bookRepository.GetBookByIsbn(isbn);   
                if (livroExiste == null)
                {
                    response.Message = "Livro não existe";
                    return response;
                }
                var bookDetailsDTO = _mapper.Map<BookDTO>(livroExiste);
                response.Message = "Livro encontrado";
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
                        response.Message = "Livro criado com sucesso";
                        response.Obj = _mapper.Map<BookDTO>(bookAdd);
                        response.Success = true;
                        return response;

                    }
                    response.Message = "Preencha os campos corretamente";
                    return response;
                }
                response.Message = "Livro já existe";
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
       public async Task<MessangingHelper<BookDTO>> RemoveBook(string isbn)
       {
            MessangingHelper<BookDTO> response = new();
            try
           {
               if (isbn.Length != 13)
               {
                    response.Message = "O ISBN precisa ter 13 caracteres";
                    return response;
                }

               var livro = await _bookRepository.GetBookByIsbn(isbn);

               if (livro != null )
               {
                    var removerLivro = await _bookRepository.RemoveOneBook(isbn);
                    // Map Book entity to BookDTO
                    var mappedBook = _mapper.Map<BookDTO>(removerLivro);
                    response.Message = "Livro removido com sucesso";
                    response.Obj = mappedBook;
                    response.Success = true;
                    return response;
                }
               else
               {
                    response.Message = "Livro não existe";
                    return response;
                }

           }
           catch (Exception)
           {
               throw;
           }
       }
       
       public async Task<MessangingHelper<BookDTO>> EditBook(string isbn, BookDTO bookDTO)  
       {
           try
           {
                MessangingHelper<BookDTO> response = new();

                if (isbn.Length != 13)
                {
                    response.Message = "O ISBN precisa ter 13 caracteres";
                    return response;
                }
               var livroExiste = await _bookRepository.GetBookByIsbn(isbn);
               if (livroExiste == null)
               {
                    response.Message = "Livro não existe";
                    return response;
               }
               else
               {
                   if(bookDTO.ISBN != livroExiste.ISBN || bookDTO.Name.Length <=1 || bookDTO.Price <= 0)
                   {
                        response.Message = "Os Campos precisam ser preenchidos corretamente";
                        return response; 
                   }
                   // var mappedBook = _mapper.Map<Book>(bookDTO);
                    livroExiste.UpdateBook(bookDTO.Name, bookDTO.Price);
                    var livroEditado = await _bookRepository.EditOneBook(livroExiste);

                    response.Message = "Livro editado com sucesso";
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
