﻿using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class AuthorDtoForDetails
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string BornDeatYear { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public List<BookDto> Books { get; set; } // Kitaplar ile ilişki
    }

    public class BookDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
    }
}
