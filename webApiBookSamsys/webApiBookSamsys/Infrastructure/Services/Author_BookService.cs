using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApiBookSamsys.Infrastructure.Entities;
using webApiBookSamsys.Infrastructure.Entities.DTOs;
using webApiBookSamsys.Infrastructure.MessagingHelper;
using webApiBookSamsys.Infrastructure.Repository;

namespace webApiBookSamsys.Infrastructure.Services
{
    public class Author_BookService
    {
        private readonly Author_BookRepository _author_BookRepository;  
        private readonly AuthorRepository _authorRepository;    
        private readonly BookRepository _bookRepository;    
        private readonly IMapper _mapper;

        public Author_BookService(Author_BookRepository author_BookRepository, AuthorRepository authorRepository, BookRepository bookRepository , IMapper mapper)   
        {
            _author_BookRepository = author_BookRepository;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;   
            _mapper = mapper;
        }


        public async Task<MessangingHelper<Author_bookDTO>> PostRelationship([FromBody] Author_bookDTO author_Book)  
        {
            MessangingHelper<Author_bookDTO> response = new();


            var mappedRelationship = _mapper.Map<Author_Book>(author_Book);
            var newRelationship = await _author_BookRepository.PostRelationship(mappedRelationship);
            response.Message = "Relação livro e autor criada com sucesso";
            response.Obj = _mapper.Map<Author_bookDTO>(newRelationship);
            response.Success = true;
            return response;
        }


    }
}
