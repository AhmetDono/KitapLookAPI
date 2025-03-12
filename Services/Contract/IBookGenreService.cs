using Entitites.DataTransferObject;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IBookGenreService
    {
        Task<BookGenre> CreateOneBookGenreAsync(BookGenreDtoForCreate bookGenreDto);
        Task DeleteOneBookGenreAsync(int bookId,int genreId, bool trackChanges);
        Task UpdateOneBookGenreAsync(int bookId, int genreId, BookGenreDtoForUpdate bookGenreDto, bool trackChanges);
        Task<BookGenre> GetOneBookGenreByBookIdAsync(int id, bool trackChanges);
        Task<BookGenre> GetOneBookGenreByGenreIdAsync(int id, bool trackChanges);
        Task<IEnumerable<BookGenre>> GetAllBookGenresAsync(bool trackChanges);
    }
}
