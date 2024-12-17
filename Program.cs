using MovieApp.Dtos;
namespace MovieApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            const string getMovieEndPoint = "GetMovie";

            app.MapGet("/", () => "Hello World!");


            List<MovieDto> movies = [
                new MovieDto(1,"The Shawshank Redemption", "Drama","Frank Darabont",14.5, new DateOnly(1994,10,14)),
                new MovieDto(2,"The Godfather", "Crime", "Francis Ford Coppola",8.6, new DateOnly(1972,4,24)),
                new MovieDto(3,"The Dark Knight", "Action", "Christopher Nolan", 25.5, new DateOnly(2008,7,18))
           ];



            // GET /movies all data
            app.MapGet("Movies", () => movies);

            // GET /movies/1
            app.MapGet("Movies/{id}",(int id) => movies.Find(m=>m.Id==id)).WithName(getMovieEndPoint);


            // update existing one
            //app.MapPut("Movies/{id}", (MovieDto movie) =>
            //{
            //    movies[movie.Id] = movie; 
            //    return 
            //})


            // POST /Movies create a new movie
            app.MapPost("Movies", (CreateMovieDto createMovieDto) =>
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
            app.MapPut("Movies/{id}", (int id,UpdateMovieDto updateMovieDto) =>
            {
                int index = movies.FindIndex(m=>m.Id == id);
                movies[index] = new MovieDto(
                    index+1,
                    updateMovieDto.Title,
                    updateMovieDto.Genre,
                    updateMovieDto.Director,
                    updateMovieDto.TicketPrice,
                    updateMovieDto.ReleaseDate
                    );
                 
                return Results.NoContent();
            });

            //DELETE /Movies/1 delete a movie
            app.MapDelete("Movies/{id}", (int id) =>
            {
                
                movies.RemoveAll(m=>m.Id==id);

                return Results.NoContent();
            });




            app.Run();
        }
    }
}
