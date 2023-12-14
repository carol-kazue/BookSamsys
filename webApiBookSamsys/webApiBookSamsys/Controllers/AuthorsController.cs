using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.Entities.DTOs;
using webApiBookSamsys.Infrastructure.MessagingHelper;
using webApiBookSamsys.Infrastructure.Services;

namespace webApiBookSamsys.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;  

        public AuthorsController(AuthorService authorService)   
        {
            _authorService = authorService;
        }

        // GET: api/Authors
        [HttpGet("autores")]
        public async Task<MessangingHelper<List<Author>>> GetAuthors()
        {
            return await _authorService.GetAuthors();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<MessangingHelper<Author>> GetAuthorById( long id)
        {
            return await _authorService.GetAuthorById(id);
        }

        // PUT: api/Authors/5
        
        [HttpPut("{id}")]
        public async Task<MessangingHelper<AuthorCreateDTO>> PutAuthor (long id, AuthorCreateDTO authorCreateDTO)
        {
            return await _authorService.PutAuthor(id, authorCreateDTO);
        }

        // POST: api/Authors
        
        [HttpPost("autor")]
        public async Task<MessangingHelper<AuthorCreateDTO>> PostAuthor([FromBody] AuthorCreateDTO authorCreateDTO)
        {
            return await _authorService.PostAuthor(authorCreateDTO);
        }



        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<MessangingHelper<Author>> DeleteAuthor(long id)
        {
            return await _authorService.DeleteAuthor(id);
        }


    }
}
