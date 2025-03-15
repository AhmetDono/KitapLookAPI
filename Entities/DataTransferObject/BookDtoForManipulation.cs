using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.DataTransferObject
{
    public abstract record BookDtoForManipulation
    {
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public int AuthorID { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string Publisher { get; set; }
        public string CoverImage { get; set; }
        public List<GenreIdDto> BookGenre { get; set; }
    }

    public class GenreIdDto
    {
        public int GenreId { get; set; }
    }
}
