using Microsoft.AspNetCore.Mvc;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.Entities.DTOs;

namespace webApiBookSamsys.Infrastructure.Repository
{
    public class Author_BookRepository
    {
        private readonly BookSamsysContext _context;

        public Author_BookRepository(BookSamsysContext context)
        {
            _context = context;
        }

        public async Task<Author_Book> PostRelationship([FromBody] Author_Book author_Book) 
        {
            await _context.AddAsync(author_Book);
            await _context.SaveChangesAsync();
            return author_Book;
        }

        public async Task<List<Author_Book>> GetRelashionship()
        {
            var list = _context.Author_Books.ToList();
            return list;
        }
       
    }
}
