using MovieApp.Data;
using MovieApp.Dtos;
using MovieApp.Entities;

namespace MovieApp.Mapping
{
    public static class MovieMapping
    {
        public static Movie ToEntity(this CreateMovieDto createMovieDto)
        {
            return new Movie
            {
                Title = createMovieDto.Title,
                GenreId = createMovieDto.GenreId,
                Director = createMovieDto.Director,
                TicketPrice = createMovieDto.TicketPrice,
                ReleaseDate = createMovieDto.ReleaseDate,

            };

        }

        public static Movie ToEntity(this UpdateMovieDto updateMovieDto, int id)
        {
            return new Movie()
            {
                Id = id,
                Title = updateMovieDto.Title,
                GenreId = updateMovieDto.GenreId,
                Director = updateMovieDto.Director,
                TicketPrice = updateMovieDto.TicketPrice,
                ReleaseDate = updateMovieDto.ReleaseDate
            };
        }


        // map Movie to MovieSummaryDto
        public static MovieSummaryDto MapToMovieSummaryDto(this Movie movie)
        {
            MovieSummaryDto movieSummaryDto = new(
                            movie.Id,
                            movie.Title,
                            movie.Genre!.Name,
                            movie.Director,
                            movie.TicketPrice,
                            movie.ReleaseDate

                        );
            return movieSummaryDto;

        }


        public static MovieDetailsDto MapToMovieDetailsDto(this Movie movie)
        {
            MovieDetailsDto movieDetailsDto = new(
                            movie.Id,
                            movie.Title,
                            movie.GenreId,
                            movie.Director,
                            movie.TicketPrice,
                            movie.ReleaseDate

                        );
            return movieDetailsDto;

        }



    }
}
