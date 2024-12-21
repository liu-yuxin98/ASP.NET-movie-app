namespace MovieApp.Frontend.Models
{
    public class MovieSummary
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Genre {  get; set; }

        public required string Director { get; set; }

        public decimal TicketPrice { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
