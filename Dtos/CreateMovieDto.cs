using System.ComponentModel.DataAnnotations;

namespace MovieApp.Dtos
{
    public record class CreateMovieDto(
        [Required][StringLength(100)] string Title,
        [Required][StringLength(50)] string Genre,
        string Director,
        [Range(0, 200)] decimal TicketPrice,
        DateOnly ReleaseDate
        );
}
