using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class BookGenre
    {
        public int BookID { get; set; }
        public int GenreID { get; set; }

        // Kitap ile Tür arasındaki ilişkiler
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
