using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.EndPoints;


namespace MovieApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("Movie");
            builder.Services.AddSqlite<MovieContext>(connString);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.MapMoviesEndPoints();

            app.MigrateDb();

            app.Run();
        }
    }
}
