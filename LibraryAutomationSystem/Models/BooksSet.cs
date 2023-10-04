using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.Models
{
    public class BooksSet
    {

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string Publisher { get; set; }
        public string Translator { get; set; }
        public int PageCount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReaderId { get; set; }
        public int LibrarianId { get; set; }




    }
}