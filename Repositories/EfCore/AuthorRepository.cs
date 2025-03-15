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
    //Repo base i çağırarak hem generic işlemleri kullanabiliyoruz
    //Hem de IAuthorRepo ile eğer IauthorRepo için tanımladıysak özel işlemier kullanabiliyoruz
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext context) : base(context)
        {

        }

        public async Task<PagedList<Author>> GetAllWithIncludesAsync(AuthorParameters authorParameters,bool trackChanges)
        {
            var query = await FindAllAsync(trackChanges);

            var filteredQueryAuthors = query
                .SearchAuthors(authorParameters.SearchTerm)
                .SortAuthors(authorParameters.OrderBy)
                .Include(a => a.Books);

            return PagedList<Author>.ToPagedList(
               filteredQueryAuthors,
               authorParameters.PageNumber,
               authorParameters.PageSize);
        }

        public async Task<Author> GetAuthorByIdAsync(int id, bool trackChanges)
        {
            var query = await FindByConditionAsync(a => a.Id.Equals(id), trackChanges);

            return await query
                .Include(a => a.Books)
                .SingleOrDefaultAsync();
        }
    }
}
