using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business.Dto
{
    public class BookDTO
    {

        public string Title { get; set; }

        public string Author { get; set; }

        public string Theme { get; set; }

        public DateTime published { get; set; }

        public int AuthorId { get; set; }

    }
}
