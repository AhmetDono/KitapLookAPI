using Entitites.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class BookDtoForDetails
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int PublishedYear { get; set; }
        public string CoverImage { get; set; }

        // Sadece yazar adı
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorBio { get; set; }
        public string BornDeatYear { get; set; }

        // Sadece GenreID listesi
        public List<GenreDtoForBook> Genres { get; set; }

    }

    public class GenreDtoForBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
