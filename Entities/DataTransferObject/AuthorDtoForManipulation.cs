using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.DataTransferObject
{
    public abstract record AuthorDtoForManipulation
    {
        public string AuthorName { get; set; }
        public string BornDeatYear { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
    }
}
