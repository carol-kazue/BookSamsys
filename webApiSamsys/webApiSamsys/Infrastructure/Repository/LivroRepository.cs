using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;
using webApiSamsys.Infrastructure.Entities;
using static webApiSamsys.Infrastructure.MessengerHelper.MessengerHelper;

namespace webApiSamsys.Infrastructure.Repository
{
    
    public class LivroRepository
    {
        private readonly BookSamsysContext _context;

        public LivroRepository(BookSamsysContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Livro>> GetAllBook()  
        {
            return await _context.Livros.Select(l => l).ToListAsync();

        }

        public async Task<IEnumerable<Livro>> GetBookById(int isbn)      
        {
           return await _context.Livros.Select(l => l).Where(l => l.ISBN == isbn).ToListAsync();
        }

        public async Task<Livro> AddOneBook(Livro livro)    
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
            return livro;
        }
    }

}
