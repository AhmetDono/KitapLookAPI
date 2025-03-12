using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
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

        public async Task<IEnumerable<Genre>> GetAllWithIncludesAsync(bool trackChanges)
        {
            var query = await FindAllAsync(trackChanges);

            var filteredQuery = query
                .Include(g => g.BookGenres)
                .ThenInclude(ge => ge.Book)
                .ToListAsync();

            return await filteredQuery;
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
