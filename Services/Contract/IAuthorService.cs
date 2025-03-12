using Entitites.DataTransferObject;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    //Burada ki tanımlamaların içini manager kısmında dolduracağız
    //Bu doldurulan managerları da Repo işlemlerini kullanacağız
    //Ve bu managerları da controllerlar da gerekli yerde çağıracağız yani
    //Repo=>Service(Manager)=>Controller Yapısını kuruyoruz
    //Burada örnek create işlemi açıyoruz
    //Manager kısmında repolar ile create işleminin içini dolduruyoruz yani create işlemini gerçekleştiriyoruz
    //Controller kısmındada gerekli işlemleri endpointe çekiyoruz
    public interface IAuthorService
    {
        Task<Author> CreateOneAuthorAsync(AuthorDtoForCreate authorDto);
        Task DeleteOneAuthorAsync(int id, bool trackChanges);
        Task UpdateOneAuthorAsync(int id, AuthorDtoForUpdate authorDto, bool trackChanges);
        Task<Author> GetOneAuthorByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
    }
}
