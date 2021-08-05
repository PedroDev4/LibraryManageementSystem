using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business.Models
{
    public class Book : Entity
    {

        public string Title { get; set; }

        public string Theme { get; set; }

        public DateTime Published { get; set; }

        public bool isAvailable { get; set; }

        // EF Relations
        public int AuthorId { get; set; }

        public List<Author> Authors { get; set; }


    }
}
