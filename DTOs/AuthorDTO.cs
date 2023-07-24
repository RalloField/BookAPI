using BookWebAPI.Models;
namespace BookWebAPI.DTOs

{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public int? CountryId { get; set; }



    }
}
