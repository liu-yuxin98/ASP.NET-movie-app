using MovieApp.Dtos;
using MovieApp.EndPoints;
namespace MovieApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();


            app.MapGet("/", () => "Hello World!");
            app.MapMoviesEndPoints();


            app.Run();
        }
    }
}
