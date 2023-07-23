namespace BookWebAPI.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection <Books>? Books { get; set; }
    }
}
