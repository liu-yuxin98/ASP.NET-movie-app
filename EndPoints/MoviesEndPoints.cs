using MovieApp.Dtos;

namespace MovieApp.EndPoints
{
    public static class MoviesEndPoints
    {

        const string getMovieEndPoint = "GetMovie";
        private static List<MovieDto> movies = [
            new MovieDto(1,"The Shawshank Redemption", "Drama","Frank Darabont",14.5M, new DateOnly(1994,10,14)),
                new MovieDto(2,"The Godfather", "Crime", "Francis Ford Coppola",8.6M, new DateOnly(1972,4,24)),
                new MovieDto(3,"The Dark Knight", "Action", "Christopher Nolan", 25.5M, new DateOnly(2008,7,18))
       ];


        public static RouteGroupBuilder MapMoviesEndPoints(this WebApplication app)
        {

            var group = app.MapGroup("Movies")
                            .WithParameterValidation();
            // GET /movies all data
            group.MapGet("/", () => movies);

            // GET /movies/1
            group.MapGet("/{id}", (int id) =>
            {
                MovieDto? movieDto = movies.Find(x => x.Id == id);
                return movieDto is null ? Results.NotFound() : Results.Ok(movieDto);
            }).WithName(getMovieEndPoint);


            // POST /Movies create a new movie
            group.MapPost("/", (CreateMovieDto createMovieDto) =>
            {
                MovieDto movieDto = new MovieDto(
                    movies.Count + 1,
                    createMovieDto.Title,
                    createMovieDto.Genre,
                    createMovieDto.Director,
                    createMovieDto.TicketPrice,
                    createMovieDto.ReleaseDate
                    );
                movies.Add(movieDto);
                return Results.CreatedAtRoute(getMovieEndPoint, new { id = movieDto.Id }, movieDto);
            });

            //PUT /Movies/1 update a movie
            group.MapPut("/{id}", (int id, UpdateMovieDto updateMovieDto) =>
            {
                int index = movies.FindIndex(m => m.Id == id);
                if (index == -1)
                {
                    return Results.NotFound();
                }

                movies[index] = new MovieDto(
                    index + 1,
                    updateMovieDto.Title,
                    updateMovieDto.Genre,
                    updateMovieDto.Director,
                    updateMovieDto.TicketPrice,
                    updateMovieDto.ReleaseDate
                    );

                return Results.NoContent();
            });

            //DELETE /Movies/1 delete a movie
            group.MapDelete("/{id}", (int id) =>
            {

                movies.RemoveAll(m => m.Id == id);

                return Results.NoContent();
            });


            return group;


        }



    }
}
