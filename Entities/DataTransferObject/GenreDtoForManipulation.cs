using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.DataTransferObject
{
    public abstract record GenreDtoForManipulation
    {
        public string Name { get; set; }
    }
}
