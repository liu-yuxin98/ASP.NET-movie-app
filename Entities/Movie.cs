namespace MovieApp.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public required string Director { get; set; }

        public decimal TicketPrice { get; set; }
        public DateOnly ReleaseDate {  get; set; }

    }
}
