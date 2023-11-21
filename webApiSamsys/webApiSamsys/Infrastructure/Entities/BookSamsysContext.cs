using Microsoft.EntityFrameworkCore;

namespace webApiSamsys.Infrastructure.Entities
{
    public class BookSamsysContext: DbContext
    {
        public BookSamsysContext(DbContextOptions options) : base(options) { }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Autor_livro> Autor_livros { get; set; }    
    }
}
