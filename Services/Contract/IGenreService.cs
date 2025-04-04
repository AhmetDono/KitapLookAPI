﻿using Entities.DataTransferObject;
using Entitites.DataTransferObject;
using Entitites.Models;
using Entitites.RequestFeatures;
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
        Task<GenreDtoForDetails> GetOneGenreByIdAsync(int id, bool trackChanges);
        Task<(IEnumerable<GenreDtoForDetails>, MetaData metadata)> GetAllGenresAsync(GenreParameters genreParameters, bool trackChanges);
    }
}
