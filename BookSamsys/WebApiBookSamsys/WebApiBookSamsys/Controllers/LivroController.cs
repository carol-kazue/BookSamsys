using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiBookSamsys.Infrastructure.Services;
using WepApiBookSamsys.Infrastructure.Entities;
using WebApiBookSamsys.Infrastructure.DTOs;
using static WebApiBookSamsys.Infrastructure.MenssageHelper;
using System.Data.Entity;

namespace WebApiBookSamsys.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroService _serviceLivro ;    

        public LivroController(LivroService service)
        {
            _serviceLivro = service;
        }

        // GET: api/Livros pega a lista de livros somente 
        [HttpGet]
        [Route("livros")]
        public async Task<MessageHelper<IEnumerable<Livro>>> GetAll()
        {
            return await _serviceLivro.GetLivros();
        }

        
        // GET: api/Livro/5 pega um livro 
        [HttpGet]
        [Route("livro/{isbn}")]
        public async Task<MessageHelper<IEnumerable<LivroDTO>>>GetBookByIsbn(int isbn)
        {
            return await _serviceLivro.GetLivro(isbn);
        }

        // POST: api/Livro Criar novo livro juntamente com o id do autor 
        [HttpPost]
        [Route("add-livro")]
        public async Task<MessageHelper<IEnumerable<LivroNovoDTO>>> PostBook (LivroNovoDTO livro)
        {
            return await _serviceLivro.PostLivro(livro);
        }
        /*
        // PUT: api/Livro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.ISBN)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
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

        

        // DELETE: api/Livro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            if (_context.Livros == null)
            {
                return NotFound();
            }
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivroExists(int id)
        {
            return (_context.Livros?.Any(e => e.ISBN == id)).GetValueOrDefault();
        }
        */
    }
}
