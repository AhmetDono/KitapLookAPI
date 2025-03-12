using AutoMapper;
using Entities.DataTransferObject;
using Entitites.DataTransferObject;
using Entitites.Models;
using Repositories.Contracts;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthorManager : IAuthorService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AuthorManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<Author> CreateOneAuthorAsync(AuthorDtoForCreate authorDto)
        {
            if(authorDto is null)
            {
                throw new ArgumentNullException(nameof(authorDto));
            }

            var author = _mapper.Map<Author>(authorDto);

            await _manager.Author.CreateAsync(author);
            await _manager.SaveAsync();

            return author;
        }

        public async Task DeleteOneAuthorAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Author.GetAuthorByIdAsync(id,trackChanges);

            if(entity is null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }

            await _manager.Author.DeleteAsync(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges)
        {
            var authors = await _manager.Author.FindAllAsync(trackChanges);

            return authors;
        }

        public async Task<AuthorDtoForDetails> GetOneAuthorByIdAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Author.GetAuthorByIdAsync(id,trackChanges);

            var author = _mapper.Map<AuthorDtoForDetails>(entity);

            return author;
        }

        public async Task UpdateOneAuthorAsync(int id, AuthorDtoForUpdate authorDto, bool trackChanges)
        {
            var entity = await _manager.Author.GetAuthorByIdAsync(id, trackChanges);

            if(entity is null)
            {
                throw new ArgumentNullException($"{nameof(authorDto)} is null");
            }

            entity = _mapper.Map<Author>(authorDto);

            await _manager.Author.UpdateAsync(entity);
            await _manager.SaveAsync();
        }
    }
}
