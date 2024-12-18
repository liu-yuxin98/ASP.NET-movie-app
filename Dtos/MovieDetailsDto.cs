using System.ComponentModel.DataAnnotations;

namespace MovieApp.Dtos
{
    // record is mainly used to store data
    public record class MovieDetailsDto(
        int Id,
        string Title,
        int GenreId,
        string Director,
        decimal TicketPrice,
        DateOnly ReleaseDate
    );

}
