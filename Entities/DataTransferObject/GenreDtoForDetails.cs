using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class GenreDtoForDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BookDtoForGenre> BookGenres { get; set; }
    }

    public class BookDtoForGenre
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
    }

}
