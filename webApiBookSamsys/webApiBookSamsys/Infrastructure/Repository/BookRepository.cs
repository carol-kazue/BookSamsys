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
            var books = _context.Books.ToList();
            return books;
        }
       // public async Task<List<BookDTO>> GetBooksAuthors()


        //pesquisar porque o async não tá fucionando e porque o FindeDefault tbm não 
        public async Task<Book> GetBookByIsbn(string isbn)  
        {
            // .Find é usada para encontrar chave primária o que não é o caso aqui 
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            return book;
        }

        public async Task<List<long>> GetAuthorIdByISBN(string isbn)
        {
            var idAuthors = _context.Author_Books.Where(b => b.ISBN == isbn).Select(a => a.IdAuthor).ToList();
            return idAuthors;
        }



        public async Task<Book> PostNewBook([FromBody] Book newBook)   
         {
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook;
         }
        
        public async Task<Book> RemoveOneBook(string isbn)
        {
            var book = _context.Books.FirstOrDefault(b => b.ISBN == isbn);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Book> EditOneBook(Book book)
        {
             await _context.SaveChangesAsync();
            return book;
        }
    }
}
