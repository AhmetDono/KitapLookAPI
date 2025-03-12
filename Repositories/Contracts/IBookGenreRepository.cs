using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookGenreRepository : IRepositoryBase<BookGenre>
    {
        // Belirli bir kitaba ait tüm genreler
        Task<BookGenre> GetGenresByBookIdAsync(int bookId,bool trackChanges);

        // Belirli bir genre'ye ait tüm kitaplar
        Task<BookGenre> GetBooksByGenreIdAsync(int genreId, bool trackChanges);

        // İki ID'ye göre (Composite Key)
        Task<BookGenre> GetByBookAndGenreIdAsync(int bookId, int genreId, bool trackChanges);
    }
}
