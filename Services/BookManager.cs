using AutoMapper;
using Entities.DataTransferObject;
using Entitites.DataTransferObject;
using Entitites.Models;
using Repositories.Contracts;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly IBookGenreService _bookGenreService;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager, IMapper mapper, IBookGenreService bookGenreService)
        {
            _manager = manager;
            _mapper = mapper;
            _bookGenreService = bookGenreService;
        }

        public async Task<Book> CreateOneBookAsync(BookDtoForCreate bookDto)
        {
            if (bookDto is null)
            {
                throw new ArgumentNullException(nameof(bookDto));
            }

            // Book create edip id sini aliyoruz ve sonra bookgenre create edecegiz
            var book = _mapper.Map<Book>(bookDto);
            await _manager.Book.CreateAsync(book);
            await _manager.SaveAsync();

            // Şimdi GenreId listesinden BookGenre kayıtları oluştur
            if (bookDto.BookGenre != null && bookDto.BookGenre.Any())
            {
                foreach (var genreId in bookDto.BookGenre)
                {
                    var bookGenre = new BookGenreDtoForCreate
                    {
                        BookID = book.Id, // Kitap ID'si (az önce oluştu)
                        GenreID = genreId.GenreId,
                    };

                    await _bookGenreService.CreateOneBookGenreAsync(bookGenre);
                }
            }
                return book;
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetBookByIdAsync(id,trackChanges);

            if (entity is null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }

            await _manager.Book.DeleteAsync(entity);
            await _manager.SaveAsync();

        }

        public async Task<IEnumerable<BookDtoForDetails>> GetAllBooksAsync(bool trackChanges)
        {
            var entities = await _manager.Book.GetAllWithIncludesAsync(trackChanges);

            var books = _mapper.Map<IEnumerable<BookDtoForDetails>>(entities);

            return books;
        }

        public async Task<BookDtoForDetails> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetBookByIdAsync(id, trackChanges);

            var book = _mapper.Map<BookDtoForDetails>(entity);
            return book;
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = await _manager.Book.GetBookByIdAsync(id, trackChanges);

            if (entity is null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }

            entity = _mapper.Map<Book>(bookDto);

            await _manager.Book.UpdateAsync(entity);
            await _manager.SaveAsync();
        }
    }
}
