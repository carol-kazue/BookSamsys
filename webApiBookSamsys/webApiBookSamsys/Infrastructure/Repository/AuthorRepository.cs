using Microsoft.AspNetCore.Mvc;
using webApiBookSamsys.Infrastructure.Entities;

namespace webApiBookSamsys.Infrastructure.Repository
{
    public class AuthorRepository
    {
        private readonly BookSamsysContext _context;

        public AuthorRepository(BookSamsysContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAuthors()
        {
            var authors = _context.Author.ToList();
            return authors;
        }
        public async Task<Author> GetAuthorById(long id)  
        {
            var author = _context.Author.Find(id);
            return author;
        }


        public async Task<Author> PutAuthor(Author author)
        {
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author>PostAuthor([FromBody] Author newAuthor)
        {
            await _context.Author.AddAsync(newAuthor);
            await _context.SaveChangesAsync();
            return newAuthor;
        }

        public async Task<Author>GetAuthorByName (string name)
        {
            var authorName = _context.Author.FirstOrDefault(a => a.Name == name);
            return authorName;
        }

        public async Task <Author>DeleteAuthor (long id)
        {
            var author = _context.Author.Find(id);
            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
            return author;
        }


    }
}
