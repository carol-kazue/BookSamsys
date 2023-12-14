using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.Entities.DTOs;
using webApiBookSamsys.Infrastructure.MessagingHelper;
using webApiBookSamsys.Infrastructure.Repository;

namespace webApiBookSamsys.Infrastructure.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository; 
        private readonly IMapper _mapper;   
       
        public AuthorService(AuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<MessangingHelper<List<Author>>> GetAuthors()
        {
            MessangingHelper<List<Author>> response = new();

            try
            {
                var authors = await _authorRepository.GetAuthors();

                if (authors == null)
                {
                    response.Message = "Não existe autores na lista";
                    return response;
                }
                response.Message = "Retorno da lista de autores foi bem sucedida";
                response.Obj = authors;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<MessangingHelper<Author>> GetAuthorById(long id)
        {
            MessangingHelper<Author> response = new();

            try
            {
                var author = await _authorRepository.GetAuthorById(id);
                if (author == null)
                {
                    response.Message = "Autor não existe";
                    return response;
                }
                response.Message = "Autor encontrado";
                response.Obj = author;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessangingHelper<AuthorCreateDTO>> PutAuthor( long id, AuthorCreateDTO authorCreateDTO)    
        {
            MessangingHelper<AuthorCreateDTO> response = new();
            try
            {

                var idAuthorExist = await _authorRepository.GetAuthorById(id);

                if (idAuthorExist == null)
                {
                    response.Message = "Autor não existe";
                    return response;
                }

                var author = _mapper.Map<Author>(idAuthorExist);

                author.UpdateAuthor(authorCreateDTO.Name);
                var authorEdited = await _authorRepository.PutAuthor(author);

                response.Message = "Livro editado com sucesso";
                response.Obj = _mapper.Map<AuthorCreateDTO>(authorEdited);
                response.Success = true;
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<MessangingHelper<AuthorCreateDTO>>PostAuthor([FromBody] AuthorCreateDTO authorCreateDTO)
        {
            MessangingHelper<AuthorCreateDTO> response = new();
            
            try
            {
                    var mappedAuthor = _mapper.Map<Author>(authorCreateDTO);
                    var newAuthor = await _authorRepository.PostAuthor(mappedAuthor);
                    response.Message = "Autor criado com sucesso";
                    response.Obj = _mapper.Map<AuthorCreateDTO>(newAuthor);
                    response.Success = true;
                    return response;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessangingHelper<Author>> DeleteAuthor(long id)
        {
            MessangingHelper<Author> response = new();
            try
            {
                var authorExist = await _authorRepository.GetAuthorById(id);

                if (authorExist == null)
                {
                    response.Message = "Autor não existe";
                    return response;
                }
                var author = await _authorRepository.DeleteAuthor(id);
                response.Message = "Autor deletado com sucesso";
                response.Obj = author;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }

        
    }
}
