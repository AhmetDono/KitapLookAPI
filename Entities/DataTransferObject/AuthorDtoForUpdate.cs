using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.DataTransferObject
{
    public record AuthorDtoForUpdate : AuthorDtoForManipulation
    {
        public int Id { get; set; }
    }
}
