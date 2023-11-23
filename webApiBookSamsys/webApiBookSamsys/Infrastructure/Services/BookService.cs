using Microsoft.AspNetCore.Mvc;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.MessagingHelper;
using webApiBookSamsys.Infrastructure.Repository;
using System.Linq;

namespace webApiBookSamsys.Infrastructure.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService (BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetBooks()    
        {
           // string errorMessage = "Ocorreu um erro enquanto era buscado o livro";
            
            try
            {
                var livros = await _bookRepository.GetAllBooks();
                if (livros == null)
                {
                    return NotFound("Não existe livro na lista");
                    
                }
                return livros;
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno.");
            }

        }

        private List<Book> NotFound(string v)
        {
            throw new NotImplementedException();
        }

        private List<Book> StatusCode(int v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
