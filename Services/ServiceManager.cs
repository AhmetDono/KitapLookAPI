using AutoMapper;
using Repositories.Contracts;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IGenreService> _genreSerivce;
        private readonly Lazy<IBookGenreService> _bookGenreService;


        public ServiceManager(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _authorService = new Lazy<IAuthorService>(()=> new AuthorManager(repositoryManager, mapper));
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, mapper, _bookGenreService.Value));
            _genreSerivce = new Lazy<IGenreService>(()=> new GenreManager(repositoryManager, mapper));
            _bookGenreService = new Lazy<IBookGenreService>(()=> new BookGenreManager(repositoryManager,mapper));
        }

        public IBookService BookService => _bookService.Value;

        public IAuthorService AuthorService => _authorService.Value;

        public IGenreService GenreService => _genreSerivce.Value;

        public IBookGenreService BookGenreService => _bookGenreService.Value;
    }
}
