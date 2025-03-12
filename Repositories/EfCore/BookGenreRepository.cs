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
    public class BookGenreRepository : RepositoryBase<BookGenre>, IBookGenreRepository
    {
        public BookGenreRepository(RepositoryContext context) : base(context)
        {

        }

        public async Task<BookGenre> GetBooksByGenreIdAsync(int genreId, bool trackChanges)
        {
            var query = await FindByConditionAsync(bg => bg.GenreID.Equals(genreId), trackChanges);
            return await query.SingleOrDefaultAsync();
        }

        public async Task<BookGenre> GetByBookAndGenreIdAsync(int bookId, int genreId, bool trackChanges)
        {
            var query = await FindByConditionAsync(bg => bg.BookID == bookId && bg.GenreID == genreId,
            trackChanges);

            return await query.SingleOrDefaultAsync();
        }

        public async Task<BookGenre> GetGenresByBookIdAsync(int bookId, bool trackChanges)
        {
            var query = await FindByConditionAsync(bg => bg.BookID.Equals(bookId), trackChanges);

            return await query.SingleOrDefaultAsync();
        }
    }
}
