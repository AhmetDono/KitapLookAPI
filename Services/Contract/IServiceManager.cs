using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IServiceManager
    {
        IBookService BookService { get; }
        IAuthorService AuthorService { get; }
        IGenreService GenreService { get; }
        IBookGenreService BookGenreService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
