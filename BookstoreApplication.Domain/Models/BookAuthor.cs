using BookstoreApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Domain.Models;

    public class BookAuthor
    {
        public required string ISBN { get; set; }
        public required virtual Book Book { get; set; }

        public int AuthorId { get; set; }
        public required virtual Author Author { get; set; }
    }

