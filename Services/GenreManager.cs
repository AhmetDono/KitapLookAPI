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
    public class GenreManager : IGenreService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public GenreManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<Genre> CreateOneGenreAsync(GenreDtoForCreate genreDto)
        {
            if (genreDto is null)
            {
                throw new ArgumentNullException(nameof(genreDto));
            }

            var genre = _mapper.Map<Genre>(genreDto);
            await _manager.Genre.CreateAsync(genre);

            await _manager.SaveAsync();

            return genre;
        }

        public async Task DeleteOneGenreAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Genre.GetGenreByIdAsync(id, trackChanges);

            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _manager.Genre.DeleteAsync(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<GenreDtoForDetails>> GetAllGenresAsync(bool trackChanges)
        {
            var entities = await _manager.Genre.GetAllWithIncludesAsync(trackChanges);

            var genres = _mapper.Map<IEnumerable<GenreDtoForDetails>>(entities);
            
            return genres;
        }

        public async Task<GenreDtoForDetails> GetOneGenreByIdAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Genre.GetGenreByIdAsync(id,trackChanges);

            var genre = _mapper.Map<GenreDtoForDetails>(entity);

            return genre;
        }

        public async Task UpdateOneGenreAsync(int id, GenreDtoForUpdate genreDto, bool trackChanges)
        {
            var entity = await _manager.Genre.GetGenreByIdAsync(id, trackChanges);

            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity = _mapper.Map<Genre>(genreDto);

            await _manager.Genre.UpdateAsync(entity);
            await _manager.SaveAsync();
        }
    }
}
