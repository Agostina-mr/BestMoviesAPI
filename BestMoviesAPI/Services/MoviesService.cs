using BestMoviesAPI.Clients;
using BestMoviesAPI.Database;
using BestMoviesAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BestMoviesAPI.Services;

public class MoviesService : IMoviesService
{
    private IMovieDataContext _context;
    private readonly ITmdbClient _tmdbClient;

    public MoviesService(IMovieDataContext movieDbContext, ITmdbClient tmdbClient)
    {
        _context = movieDbContext;
        _tmdbClient = tmdbClient;
    }
    
    public async Task RateMovie(RateDto dto)
    {
        var currentRating = await _context.Ratings.FirstOrDefaultAsync(x => x.MovieId == dto.MovieId);
        if (currentRating is not null)
        {
            var newAverage = ((currentRating.Rating * currentRating.Votes) + dto.Rating) /
                             (currentRating.Votes + 1);
            currentRating.Rating = newAverage;
            currentRating.Votes += 1;
            _context.Ratings.Update(currentRating);
            await _context.SaveChangesAsync()!;
        }
    }
    
    public async Task<MovieDto?> GetMovie(long movieId)
    {
        var movieTask =_context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);
        var movieDetailsTask = _tmdbClient.GetMovieDetails(movieId);       
        await Task.WhenAll(movieTask, movieDetailsTask);
        
        if (movieTask.Result == null) return null;
        
        return new MovieDto
        {
            Id = movieTask.Result.Id,
            Title = movieTask.Result.Title,
            Year = movieTask.Result.Year,
            Url = $"https://image.tmdb.org/t/p/w500{movieDetailsTask.Result?.PosterPath}"
        };
    }
}