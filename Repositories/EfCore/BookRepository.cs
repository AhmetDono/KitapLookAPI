using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetAllWithIncludesAsync(bool trackChanges)
        {
            var query = await FindAllAsync(trackChanges);

            var filteredQuery = query
                .Include(b => b.BookGenres)
                .ThenInclude(bo => bo.Genre)
                .Include(b => b.Author)
                .ToListAsync();

            return await filteredQuery;
        }

        public async Task<Book> GetBookByIdAsync(int id, bool trackChanges)
        {
            var query = await FindByConditionAsync(b => b.Id.Equals(id), trackChanges);

            return await query
                .Include(b => b.BookGenres)
                .ThenInclude(bo => bo.Genre)
                .Include(b => b.Author)
                .SingleOrDefaultAsync();
        }
    }
}
