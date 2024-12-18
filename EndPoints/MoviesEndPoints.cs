using MovieApp.Dtos;
using MovieApp.Data;
using MovieApp.Entities;
using MovieApp.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.EndPoints
{
    public static class MoviesEndPoints
    {

        const string getMovieEndPoint = "GetMovie";
       // private static List<MovieSummaryDto> movies = [
       //     new MovieSummaryDto(1,"The Shawshank Redemption", "Drama","Frank Darabont",14.5M, new DateOnly(1994,10,14)),
       //         new MovieSummaryDto(2,"The Godfather", "Crime", "Francis Ford Coppola",8.6M, new DateOnly(1972,4,24)),
       //         new MovieSummaryDto(3,"The Dark Knight", "Action", "Christopher Nolan", 25.5M, new DateOnly(2008,7,18))
       //];


        public static RouteGroupBuilder MapMoviesEndPoints(this WebApplication app)
        {

            var group = app.MapGroup("Movies")
                            .WithParameterValidation();
            // GET /movies all data
            group.MapGet("/", (MovieContext movieContext) => 
            movieContext.Movies
            .Include(movie => movie.Genre)
            .Select(movie => movie.MapToMovieSummaryDto())
            .AsNoTracking()
            );

            // GET /movies/1
            group.MapGet("/{id}", (int id, MovieContext movieContext) =>
            {
                Movie? movie = movieContext.Movies.Find(id);


                // map back to movieDto
                return movie is null ? Results.NotFound() : Results.Ok(movie.MapToMovieDetailsDto());
            }).WithName(getMovieEndPoint);


            // POST /Movies create a new movie
            group.MapPost("/", (CreateMovieDto createMovieDto, MovieContext movieContext) =>
            {

                Movie movie = createMovieDto.ToEntity(movieContext.Movies.Count() + 1);
                movie.Genre = movieContext.Genres.Find(movie.GenreId);
                movieContext.Movies.Add(movie);
                movieContext.SaveChanges();

                return Results.CreatedAtRoute(getMovieEndPoint, new { id = movie.Id }, movie.MapToMovieSummaryDto());
            });

            //PUT /Movies/1 update a movie
            group.MapPut("/{id}", (int id, UpdateMovieDto updateMovieDto, MovieContext movieContext) =>
            {
                var existingMovie = movieContext.Movies.Find(id);
                if (existingMovie is null)
                {
                    return Results.NotFound();
                }

                movieContext.Entry(existingMovie).CurrentValues.SetValues( updateMovieDto.ToEntity(id)
                );
                movieContext.SaveChanges();

                return Results.NoContent();
            });

            //DELETE /Movies/1 delete a movie
            group.MapDelete("/{id}", (int id, MovieContext movieContext) =>
            {

                movieContext.Movies
                .Where(movie => movie.Id == id)
                .ExecuteDelete();

                return Results.NoContent();
            });


            return group;


        }



    }
}
