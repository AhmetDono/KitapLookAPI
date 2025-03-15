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

namespace Repositories.EfCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<PagedList<Book>> GetAllWithIncludesAsync(BookParameters bookParameters,bool trackChanges)
        {
            var query = await FindAllAsync(trackChanges);

            var filteredQueryBooks = query
                .SearchBooks(bookParameters.SearchTerm)
                .SortBooks(bookParameters.OrderBy)
                .Include(b => b.BookGenres)
                .ThenInclude(bo => bo.Genre)
                .Include(b => b.Author);

            return PagedList<Book>.ToPagedList(
               filteredQueryBooks,
               bookParameters.PageNumber,
               bookParameters.PageSize);
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
