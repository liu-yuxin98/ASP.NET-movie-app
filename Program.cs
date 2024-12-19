using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.EndPoints;


namespace MovieApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("Movie");
            builder.Services.AddSqlite<MovieContext>(connString);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.MapMoviesEndPoints();
            app.MapGenresEndpoints();

            await app.MigrateDbAsync();

            app.Run();
        }
    }
}
