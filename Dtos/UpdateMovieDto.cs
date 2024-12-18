using System.ComponentModel.DataAnnotations;

namespace MovieApp.Dtos
{
    public record class UpdateMovieDto(
        int id,
        [Required][StringLength(100)] string Title,
        int GenreId,
        string Director,
        [Range(0, 200)] decimal TicketPrice,
        DateOnly ReleaseDate
        );
}
