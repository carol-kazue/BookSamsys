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
       
        public async Task<BookDTO> PostNewBook([FromBody] BookDTO newBook)   
         {
            var bookDTO = new Book
            {
                ISBN = newBook.ISBN,
                Name = newBook.Name,
                Price = newBook.Price,
            };
           _context.Books.Add(bookDTO);
           _context.SaveChanges();
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
                // Adicione outras propriedades conforme necessário
            };

            // Remover o livro do contexto
            _context.Books.Remove(book);

            // Salvar as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Retornar as informações do livro removido
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
