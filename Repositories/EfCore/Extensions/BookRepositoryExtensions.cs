using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.EfCore.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> SearchBooks(this IQueryable<Book> books, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return books;
            }

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return books
                .Where(b => b.BookTitle.ToLower().Contains(searchTerm)
                );
        }

        public static IQueryable<Book> SortBooks(this IQueryable<Book> books, string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return books.OrderBy(b => b.Id);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Book>(orderByQueryString);

            if (orderQuery is null)
            {
                return books.OrderBy(b => b.Id);
            }

            return books.OrderBy(orderQuery);
        }
    }
}
