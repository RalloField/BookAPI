namespace BookWebAPI.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }

        public int? AuthorId { get; set; }

        public AuthorDTO? Author { get; set; }
    }
}
