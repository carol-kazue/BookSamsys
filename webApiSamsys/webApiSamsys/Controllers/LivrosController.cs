﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiSamsys.Infrastructure.Entities;
using webApiSamsys.Infrastructure.Services;
using static webApiSamsys.Infrastructure.MessengerHelper.MessengerHelper;

namespace webApiSamsys.Controllers
{
    [Route("api")]
    [ApiController]
    public class LivrosController : ControllerBase   
    {
        private readonly LivroService _serviceLivro;

        public LivrosController(LivroService service)   
        {
            _serviceLivro = service;
        }


        // GET: api/Livros pega a lista de livros somente 

        [HttpGet]
        [Route("livros")]
        public async Task<MessangingHelper<IEnumerable<Livro>>> GetAll()
        {
            return await _serviceLivro.GetBooks();
        }
        
       // GET: api/Livro/5 pega um livro passando como parâmetro o isbn
       [HttpGet]
       [Route("livro/{isbn}")]
       public async Task<MessangingHelper<IEnumerable<Livro>>> GetBookByIsbn(int isbn)
       {
           return await _serviceLivro.GetBook(isbn);    
       }
       
       // POST: api/Livro Criar novo livro juntamente com o id do autor 
        [HttpPost]
        [Route("add-livro")]
        public async Task<MessangingHelper<Livro>> PostBook(Livro livro)
        {
            return await _serviceLivro.AddBook(livro);
        }

        /*
      // PUT: api/Livroes/5
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

      // POST: api/Livroes
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPost]
      public async Task<ActionResult<Livro>> PostLivro(Livro livro)
      {
        if (_context.Livros == null)
        {
            return Problem("Entity set 'BookSamsysContext.Livros'  is null.");
        }
          _context.Livros.Add(livro);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetLivro", new { id = livro.ISBN }, livro);
      }

      // DELETE: api/Livroes/5
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