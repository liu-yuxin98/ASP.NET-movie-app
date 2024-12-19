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
            group.MapGet("/", async (MovieContext movieContext) => 
            await movieContext.Movies
                    .Include(movie => movie.Genre)
                    .Select(movie => movie.MapToMovieSummaryDto())
                    .AsNoTracking()
                    .ToListAsync()
            );

            // GET /movies/1
            group.MapGet("/{id}", async (int id, MovieContext movieContext) =>
            {
                Movie? movie = await movieContext.Movies.FindAsync(id);


                // map back to movieDto
                return movie is null ? Results.NotFound() : Results.Ok(movie.MapToMovieDetailsDto());
            }).WithName(getMovieEndPoint);


            // POST /Movies create a new movie
            group.MapPost("/", async (CreateMovieDto createMovieDto, MovieContext movieContext) =>
            {

                Movie movie = createMovieDto.ToEntity();
                movieContext.Movies.Add(movie);
                await movieContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    getMovieEndPoint, 
                    new { id = movie.Id }, 
                    movie.MapToMovieDetailsDto());
            });

            //PUT /Movies/1 update a movie
            group.MapPut("/{id}",async (int id, UpdateMovieDto updateMovieDto, MovieContext movieContext) =>
            {
                var existingMovie = await movieContext.Movies.FindAsync(id);
                if (existingMovie is null)
                {
                    return Results.NotFound();
                }

                movieContext.Entry(existingMovie).CurrentValues.SetValues( updateMovieDto.ToEntity(id)
                );
                await movieContext.SaveChangesAsync();

                return Results.NoContent();
            });

            //DELETE /Movies/1 delete a movie
            group.MapDelete("/{id}", async (int id, MovieContext movieContext) =>
            {

                await movieContext.Movies
                        .Where(movie => movie.Id == id)
                        .ExecuteDeleteAsync();

                return Results.NoContent();
            });


            return group;


        }



    }
}
