namespace BookWebAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public int? CountryId { get; set; }

        public ICollection<Books> Books { get; set; }   
        public Country? Country { get; set; }
    }
}
