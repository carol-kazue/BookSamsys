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
      
        public async Task<List<BookDTO>> GetBooksAsync()
        {
            var books = _context.Books.ToList();

            // conversão de Book para BookDTO usando Select
            var booksDTO = books.Select(book => new BookDTO
            {
                // Mapeia as propriedades de Book para BookDTO conforme necessário
                // aqui provavelmente vai a lógica para ver os autores talvez um inner join no próximo passo
                ISBN = book.ISBN,
                Name = book.Name,
                Price= book.Price,
            }).ToList();
            return booksDTO;
        }
        //pesquisar porque o async não tá fucionando e porque o FindeDefault tbm não 
        public async Task<BookDTO> GetBookByIsbn(string isbn)
        {
            // .Find é usada para encontrar chave primária o que não é o caso aqui 
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            var bookDTO = new BookDTO
            {
                ISBN = book.ISBN,
                Name = book.Name,
                Price = book.Price,
            };
            return bookDTO;
            
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
        public async Task<Book> PostNewBook([FromBody] Book newBook)   
         {
            _context.Books.Add(newBook);

            // Salvando as alterações e esperando a conclusão da operação assíncrona
           _context.SaveChanges();

            // Retorna o livro adicionado (incluindo propriedades atualizadas, como a chave primária, se houver)
            return newBook;
         }
        
        public async Task<Book> RemoveOneBook(string isbn)
        {
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            //var book = _context.Books.Find(isbn);
             _context.Books.Remove(book);
             _context.SaveChanges();
            return book;
        }
        public async Task<Book> EditOneBook(string isbn, Book book)
        {
            var livroEditado = _context.Books.FirstOrDefault(l => l.ISBN == isbn);
            livroEditado.ISBN = book.ISBN;
            livroEditado.Name = book.Name;
            livroEditado.Price = book.Price;
           

            //_context.Entry(livroEditado).State= (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            _context.SaveChanges();
            return livroEditado;
        }


    }
}
