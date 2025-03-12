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
        public string ISBN { get; set; }
        public string Publisher { get; set; }

        // Sadece yazar adı
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        // Sadece GenreID listesi
        public List<int> GenreIDs { get; set; }
    }
}
