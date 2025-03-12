using AutoMapper;
using Entitites.DataTransferObject;
using Entitites.Models;
using Microsoft.AspNetCore.Http;
using Repositories.Contracts;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookGenreManager : IBookGenreService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public BookGenreManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<BookGenre> CreateOneBookGenreAsync(BookGenreDtoForCreate bookGenreDto)
        {
            if (bookGenreDto is null)
            {
                throw new ArgumentNullException(nameof(bookGenreDto));
            }

            var bookGenre = _mapper.Map<BookGenre>(bookGenreDto);

            await _manager.BookGenre.CreateAsync(bookGenre);
            await _manager.SaveAsync();

            return bookGenre;
        }

        public async Task DeleteOneBookGenreAsync(int bookId,int genreId, bool trackChanges)
        {
            var entity = await _manager.BookGenre.GetByBookAndGenreIdAsync(bookId, genreId, trackChanges);

            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _manager.BookGenre.DeleteAsync(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<BookGenre>> GetAllBookGenresAsync(bool trackChanges)
        {
            var bookGenres = await _manager.BookGenre.FindAllAsync(trackChanges);

            return bookGenres;
        }

        public Task<BookGenre> GetOneBookGenreByBookIdAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<BookGenre> GetOneBookGenreByGenreIdAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOneBookGenreAsync(int bookId,int genreId, BookGenreDtoForUpdate bookGenreDto, bool trackChanges)
        {
            var entity = await _manager.BookGenre.GetByBookAndGenreIdAsync(bookId,genreId, trackChanges);

            if(entity is null)
            {
                throw new ArgumentException(nameof(entity));
            }

            entity = _mapper.Map<BookGenre>(bookGenreDto);

            await _manager.BookGenre.UpdateAsync(entity);
            await _manager.SaveAsync();
        }
    }
}
