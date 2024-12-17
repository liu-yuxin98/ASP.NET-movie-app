namespace MovieApp.Dtos
{
    public record class CreateMovieDto(
        string Title,
        string Genre,
        string Director,
        double TicketPrice,
        DateOnly ReleaseDate
        );
}
