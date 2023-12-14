using webApiBookSamsys.Infrastructure.Entities.DTOs;
using webApiBookSamsys.Infrastructure.Entities;
using AutoMapper;


namespace webApiBookSamsys.Infrastructure.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>();

            CreateMap<BookDTO, Book>();

            CreateMap<Author, AuthorCreateDTO>();

            CreateMap<AuthorCreateDTO, Author>();

            CreateMap<Author_bookDTO, Author_Book>();

            CreateMap<Author_Book, Author_bookDTO>();

        }

    }
}
