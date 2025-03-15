using Entities.RequestFeatures;
using Entitites.Models;
using Entitites.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repositories.EfCore
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(RepositoryContext context) : base(context)
        {

        }

        public async Task<PagedList<Genre>> GetAllWithIncludesAsync(GenreParameters genreParameters, bool trackChanges)
        {
            var query = await FindAllAsync(trackChanges);

            var filteredQueryGenre = query
                .SearchGenres(genreParameters.SearchTerm)
                .SortGenres(genreParameters.OrderBy)
                .Include(g => g.BookGenres)
                .ThenInclude(ge => ge.Book);

            return PagedList<Genre>.ToPagedList(
                    filteredQueryGenre,
                    genreParameters.PageNumber,
                    genreParameters.PageSize);
        }

        public async Task<Genre> GetGenreByIdAsync(int id, bool trackChanges)
        {
            var query = await FindByConditionAsync(g => g.Id.Equals(id), trackChanges);

            return await query
                .Include(g => g.BookGenres)
                .ThenInclude(ge => ge.Book)
                .SingleOrDefaultAsync();
        }
    }
}
