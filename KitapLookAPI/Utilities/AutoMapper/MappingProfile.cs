using AutoMapper;
using Entities.DataTransferObject;
using Entitites.DataTransferObject;
using Entitites.Models;

namespace KitapLookAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDtoForCreate, Author>();
            CreateMap<AuthorDtoForUpdate, Author>();

            CreateMap<BookDtoForCreate, Book>();
            CreateMap<BookDtoForUpdate, Book>();

            CreateMap<GenreDtoForCreate, Genre>();
            CreateMap<GenreDtoForUpdate, Genre>();

            CreateMap<BookGenreDtoForCreate,BookGenre>();
            CreateMap<BookGenreDtoForUpdate,BookGenre>();

            CreateMap<Book, BookDtoForDetails>()
    .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.AuthorName))
    .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorID))
    .ForMember(dest => dest.GenreIDs, opt => opt.MapFrom(src => src.BookGenres.Select(bg => bg.GenreID)));

        }
    }
}
