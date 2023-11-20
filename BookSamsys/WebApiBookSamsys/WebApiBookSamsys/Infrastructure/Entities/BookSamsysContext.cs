using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WepApiBookSamsys.Infrastructure.Entities
{
    public class BookSamsysContext : DbContext
    {
        public BookSamsysContext(DbContextOptions options) : base(options) { }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro_autor> Livro_Autores { get; set; }
    }
}
