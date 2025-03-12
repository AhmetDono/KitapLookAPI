using Entitites.DataTransferObject;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IGenreService
    {
        Task<Genre> CreateOneGenreAsync(GenreDtoForCreate genreDto);
        Task DeleteOneGenreAsync(int id, bool trackChanges);
        Task UpdateOneGenreAsync(int id, GenreDtoForUpdate genreDto, bool trackChanges);
        Task<Genre> GetOneGenreByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges);
    }
}
