using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using webApiBookSamsys.Infrastructure.Entities;
using System.Linq;

namespace webApiBookSamsys.Infrastructure.Repository
{
    public class BookRepository
    {
        private readonly BookSamsysContext _context;    

        public BookRepository(BookSamsysContext context)
        {
            _context = context;
        }
      
        public async Task<List<Book>> GetBooksAsync()
        {
            return  _context.Books.ToList();
        }
        
        public async Task<List<Book>> GetBookByIsbn(string isbn)
        {
            return _context.Books.Where(l => l.ISBN.Contains(isbn)).ToList();
            //pesquisar porque o async não tá fucionando e porque o FindeDefault tbm não 
        }

         public async Task<Book> PostNewBook(Book newBook)   
        {
            _context.Books.Add(newBook);

            // Salvando as alterações e esperando a conclusão da operação assíncrona
           _context.SaveChanges();

            // Retorna o livro adicionado (incluindo propriedades atualizadas, como a chave primária, se houver)
            return newBook;
        }
    }
}
