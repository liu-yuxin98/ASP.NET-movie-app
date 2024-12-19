using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data
{
    public static class DataExtensions
    {

        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MovieContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
