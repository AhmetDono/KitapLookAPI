﻿using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IGenreRepository : IRepositoryBase<Genre>
    {
        Task<Genre> GetGenreByIdAsync(int id, bool trackChanges);

        Task<IEnumerable<Genre>> GetAllWithIncludesAsync(bool trackChanges);
    }
}
