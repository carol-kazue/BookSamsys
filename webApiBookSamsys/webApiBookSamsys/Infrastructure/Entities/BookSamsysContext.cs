using Microsoft.EntityFrameworkCore;
namespace webApiBookSamsys.Infrastructure.Entities
{
    public class BookSamsysContext: DbContext 
    {
        public BookSamsysContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Author_Book> Author_Books { get; set; }
    }
}
