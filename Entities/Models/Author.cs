using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string BornDeatYear { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public ICollection<Book> Books { get; set; } // Kitaplar ile ilişki
    }
}
