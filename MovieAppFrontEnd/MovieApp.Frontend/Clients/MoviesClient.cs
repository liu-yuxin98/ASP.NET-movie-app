using MovieApp.Frontend.Models;

namespace MovieApp.Frontend.Clients
{
    public class MoviesClient
    {
        private readonly List<MovieSummary> movies = [
           new(){
           Id = 1,
           Title = "The God Father",
           Genre = "Crime",
           Director = "Francis Ford Coppola",
           TicketPrice = 14.5M,
           ReleaseDate = new DateOnly(1972,04,24)
            },

       new(){
           Id = 2,
           Title = "The Shawshank Redemption",
           Genre = "Drama",
           Director = "Frank Darabont",
           TicketPrice = 23M,
           ReleaseDate = new DateOnly(1994,10,14)
            }

    ];


        public MovieSummary[] GetMovies() => [.. movies];

    }
}
