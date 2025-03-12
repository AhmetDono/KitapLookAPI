using Entitites.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    //Repo base i çağırarak hem generic işlemleri kullanabiliyoruz
    //Hem de IAuthorRepo ile eğer IauthorRepo için tanımladıysak özel işlemier kullanabiliyoruz
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
