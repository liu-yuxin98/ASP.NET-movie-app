namespace MovieApp.Dtos
{
    // record is mainly used to store data
    public record class MovieDto(
        int Id,
        string Title,
        string Genre,
        string Director,
        double TicketPrice,
        DateOnly ReleaseDate
        );

}
