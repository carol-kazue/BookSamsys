using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Book>> GetAllBooks()
        {
           var livros = await _context.Books.ToListAsync();
            return livros;
        }
        

    }
}
