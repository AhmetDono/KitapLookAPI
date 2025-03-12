using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.RequestFeatures
{
    public class BookParameters : RequestParameters
    {
        public BookParameters()
        {
            OrderBy = "Id";
        }
    }
}
