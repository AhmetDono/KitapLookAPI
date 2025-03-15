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
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<Book> GetBookByIdAsync(int id, bool trackChanges);

        Task<PagedList<Book>> GetAllWithIncludesAsync(BookParameters bookParameters,bool trackChanges);
    }
}
