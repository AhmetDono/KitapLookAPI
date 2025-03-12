using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; } // Author nesnesine erişim
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string Publisher { get; set; }
        public string CoverImage { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; } // Kitap-Tür ilişkisi
    }
}
