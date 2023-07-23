using Microsoft.EntityFrameworkCore;
 namespace BookWebAPI.Models

{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }

        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int? ShopId { get; set; }
        public Shop? Shop { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
