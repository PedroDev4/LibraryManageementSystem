using System.Collections.Generic;

namespace LibraryManagement.Business.Models
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //EF Relation
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}