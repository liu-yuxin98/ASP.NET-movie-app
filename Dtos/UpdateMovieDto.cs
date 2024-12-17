namespace MovieApp.Dtos
{
    public record class UpdateMovieDto(
        int id,
        string Title,
        string Genre,
        string Director,
        double TicketPrice,
        DateOnly ReleaseDate
        );
}
