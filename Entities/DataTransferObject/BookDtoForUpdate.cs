using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.DataTransferObject
{
    public record BookDtoForUpdate: BookDtoForManipulation
    {
        public int Id { get; set; }
    }
}
