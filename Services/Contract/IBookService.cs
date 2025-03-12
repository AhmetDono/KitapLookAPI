using Entities.DataTransferObject;
using Entitites.DataTransferObject;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IBookService
    {
        Task<Book> CreateOneBookAsync(BookDtoForCreate bookDto);
        Task DeleteOneBookAsync(int id, bool trackChanges);
        Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges);
        Task<BookDtoForDetails> GetOneBookByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
    }
}
