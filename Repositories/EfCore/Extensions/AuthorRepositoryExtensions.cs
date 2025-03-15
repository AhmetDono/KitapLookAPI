using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.EfCore.Extensions
{
    public static class AuthorRepositoryExtensions
    {
        public static IQueryable<Author> SearchAuthors(this IQueryable<Author> authors, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return authors;
            }

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return authors
                .Where(a=>a.AuthorName.ToLower().Contains(searchTerm));
        }

        public static IQueryable<Author> SortAuthors(this IQueryable<Author> authors, string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return authors.OrderBy(a => a.AuthorName);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Author>(orderByQueryString);

            if(orderQuery is null)
            {
                return authors.OrderBy(a => a.AuthorName);
            }

            return authors.OrderBy(orderQuery);
        }
    }
}
