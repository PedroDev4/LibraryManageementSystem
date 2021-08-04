namespace LibraryManagement.Business.Models
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}