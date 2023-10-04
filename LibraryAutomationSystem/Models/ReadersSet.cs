using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.Models
{
    public class ReadersSet
    {
        public int ReaderId { get; set; }
        public string ReaderName { get; set; }
        public string ReaderLastname { get; set; }

        public string ReaderPhone { get; set; }
        public bool ReaderGender { get; set; }
        public DateTime TakingDate { get; set; }
        public DateTime GivingDate { get; set; }


    }
}