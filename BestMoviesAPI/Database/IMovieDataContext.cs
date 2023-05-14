using BestMoviesAPI.Database.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMoviesAPI.Database;

public interface IMovieDataContext
{
    DbSet<Director> Directors{ get; set; }
    DbSet<Movie> Movies { get; set; }
    DbSet<Person> People { get; set; }
    DbSet<Ratings> Ratings { get; set; }
    DbSet<Star> Stars { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);  
}