using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business.Models
{
    public class Author : Entity
    {

        public string Name{ get; set; }

        public int Rating { get; set; }

        public List<Book> Books { get; set; }


    }
}
