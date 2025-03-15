using Entities.RequestFeatures;
using Entitites.Models;
using Entitites.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        Task<Author> GetAuthorByIdAsync(int id, bool trackChanges);

        Task<PagedList<Author>> GetAllWithIncludesAsync(AuthorParameters authorParameters,bool trackChanges);
    }
}
