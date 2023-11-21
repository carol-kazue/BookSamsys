using System.Data.Entity;
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
        public async Task<IEnumerable<Livro>> GetLivros()
        {
            return await _context.Livros.Select(l => l).ToListAsync();

        }
    }

}
