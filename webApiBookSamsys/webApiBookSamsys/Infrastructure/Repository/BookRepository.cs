using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using webApiBookSamsys.Infrastructure.Entities;
using System.Linq;
using NuGet.Versioning;
using webApiBookSamsys.Infrastructure.MessagingHelper;
using webApiBookSamsys.Infrastructure.Entities.DTOs;

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
            var books = await _context.Books.ToListAsync();
            return books;
        }
        //pesquisar porque o async não tá fucionando e porque o FindeDefault tbm não 
        public async Task<Book> GetBookByIsbn(string isbn)  
        {
            // .Find é usada para encontrar chave primária o que não é o caso aqui 
            var book = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
            return book;
            
        }
       
        public async Task<Book> PostNewBook([FromBody] Book newBook)   
         {
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook;
         }
        
        public async Task<BookDTO> RemoveOneBook(string isbn)
        {
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            var bookDTO = new BookDTO
            {
                ISBN = book.ISBN,
                Name = book.Name,
                Price = book.Price,
            };

            
            _context.Books.Remove(book);

           
            await _context.SaveChangesAsync();

            
            return bookDTO;
        }
        public async Task<BookDTO> EditOneBook(string isbn, BookDTO book)
        {
            var livroEditado = _context.Books.FirstOrDefault(l => l.ISBN == isbn);
            livroEditado.ISBN = book.ISBN;
            livroEditado.Name = book.Name;
            livroEditado.Price = book.Price;

            _context.SaveChanges();
            var livroEditadoDTO = new BookDTO
            {
                ISBN = livroEditado.ISBN,
                Name = livroEditado.Name,
                Price = livroEditado.Price,
            };

            return livroEditadoDTO;
        }
        /*
        *BookExists método que retorna se o livro existe, ele está como suporte para fazer as validações no service
        * ajuda a mapear as propriedades de book para bookDTO
        */

        public async Task<Book> BookExists(string isbn)
        {
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            return book;
        }
    }
}
