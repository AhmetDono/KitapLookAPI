using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IGenreRepository> _genreRepository;
        private readonly Lazy<IBookGenreRepository> _bookGenreRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_context));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
            _genreRepository = new Lazy<IGenreRepository>(()=> new GenreRepository(_context));
            _bookGenreRepository = new Lazy<IBookGenreRepository>(()=> new BookGenreRepository(_context));
        }

        public IBookRepository Book => _bookRepository.Value;

        public IAuthorRepository Author => _authorRepository.Value;

        public IGenreRepository Genre => _genreRepository.Value;

        public IBookGenreRepository BookGenre => _bookGenreRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
