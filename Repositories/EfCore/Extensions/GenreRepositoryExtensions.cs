using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.EfCore.Extensions
{
    public static class GenreRepositoryExtensions
    {
        public static IQueryable<Genre> SearchGenres(this IQueryable<Genre> genres,string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return genres;
            }

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return genres
                .Where(g => g.Name.ToLower().Contains(searchTerm)
                );
        }


        public static IQueryable<Genre> SortGenres(this IQueryable<Genre> genres, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return genres.OrderBy(g => g.Id);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Genre>(orderByQueryString);

            if (orderQuery is null)
            {
                return genres.OrderBy(g => g.Id);
            }

            return genres.OrderBy(orderQuery);
        }
    }
}
