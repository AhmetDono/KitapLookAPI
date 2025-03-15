using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Extensions
{
    public static class OrderQueryBuilder
    {
        public static String CreateOrderQuery<T>(String orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(',');

            var propertyInfos = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuild = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                //önce yukarda şu şekilde aldık id,title desc, price asc,
                //burada eğer title desc veya price asc gibi kısımlar varsa boşluk ile ayırarak title ve price 
                //kısımlarını alıcaz
                var propertyFromQueryName = param.Split(' ')[0];

                var objectProperty = propertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                //burada da desc mi asc mi olacağını alıcaz
                if (objectProperty is null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuild.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = orderQueryBuild.ToString().TrimEnd(',', ' ');


            return orderQuery;
        }
    }
}
