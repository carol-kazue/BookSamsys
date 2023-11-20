using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiBookSamsys.Infrastructure.Entities;

namespace WebApiBookSamsys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Livro_autorController : ControllerBase
    {
        private readonly BookSamsysContext _context;

        public Livro_autorController(BookSamsysContext context)
        {
            _context = context;
        }

        // GET: api/Livro_autor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro_autor>>> GetLivro_Autores()
        {
          if (_context.Livro_Autores == null)
          {
              return NotFound();
          }
            return await _context.Livro_Autores.ToListAsync();
        }

        // GET: api/Livro_autor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro_autor>> GetLivro_autor(int id)
        {
          if (_context.Livro_Autores == null)
          {
              return NotFound();
          }
            var livro_autor = await _context.Livro_Autores.FindAsync(id);

            if (livro_autor == null)
            {
                return NotFound();
            }

            return livro_autor;
        }

        // PUT: api/Livro_autor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro_autor(int id, Livro_autor livro_autor)
        {
            if (id != livro_autor.Id)
            {
                return BadRequest();
            }

            _context.Entry(livro_autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Livro_autorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Livro_autor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livro_autor>> PostLivro_autor(Livro_autor livro_autor)
        {
          if (_context.Livro_Autores == null)
          {
              return Problem("Entity set 'BookSamsysContext.Livro_Autores'  is null.");
          }
            _context.Livro_Autores.Add(livro_autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivro_autor", new { id = livro_autor.Id }, livro_autor);
        }

        // DELETE: api/Livro_autor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro_autor(int id)
        {
            if (_context.Livro_Autores == null)
            {
                return NotFound();
            }
            var livro_autor = await _context.Livro_Autores.FindAsync(id);
            if (livro_autor == null)
            {
                return NotFound();
            }

            _context.Livro_Autores.Remove(livro_autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Livro_autorExists(int id)
        {
            return (_context.Livro_Autores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
