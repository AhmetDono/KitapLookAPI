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
            .ForMember(dest => dest.AuthorImage, opt => opt.MapFrom(src => src.Author.Image))
            .ForMember(dest => dest.AuthorBio, opt => opt.MapFrom(src => src.Author.Bio))
            .ForMember(dest => dest.BornDeatYear, opt => opt.MapFrom(src => src.Author.BornDeatYear))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.BookGenres.Select(bg => new GenreDtoForBook
            {
                Id = bg.GenreID,
                Name = bg.Genre.Name
            })));

            CreateMap<Author, AuthorDtoForDetails>()
            .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books.Select(book => new BookDtoForAuthor
            {
                Id = book.Id,
                BookTitle = book.BookTitle,
                CoverImage = book.CoverImage,
                BookDescription = book.BookDescription,
            })));

            CreateMap<Genre, GenreDtoForDetails>()
                .ForMember(dest => dest.BookGenres, opt => opt.MapFrom(src => src.BookGenres.Select(
                    book => new BookDtoForGenre
                    {
                        Id = book.BookID,
                        BookTitle = book.Book.BookTitle,
                        CoverImage = book.Book.CoverImage,
                        BookDescription = book.Book.BookDescription,
                    })));
        }
    }
}