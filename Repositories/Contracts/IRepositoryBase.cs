using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        //sorgulanabilir ifadeler t şeklinde tanımlanacak buradaki t bir type (model ynai)
        //Crud tanımlanırını yapıyoruz generic şekilde genel olarak her yerde kullanılabilecek işlemler.
        //Bir sınıfa bunları Interface olarak vereceğiz ve içlerini dolduracağız

        Task<IQueryable<T>> FindAllAsync(bool trackChanges);
        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id, bool trackChanges);
    }
}
