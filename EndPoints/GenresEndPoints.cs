using MovieApp.Data;
using MovieApp.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.EndPoints
{
    public static class GenresEndpoints
    {
        public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");

            group.MapGet("/", async (MovieContext dbContext) =>
                await dbContext.Genres
                               .Select(genre => genre.ToDto())
                               .AsNoTracking()
                               .ToListAsync());

            return group;
        }
    }
}
