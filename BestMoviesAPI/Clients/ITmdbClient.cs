using BestMoviesAPI.Clients.TmdbModels;

namespace BestMoviesAPI.Clients;

public interface ITmdbClient
{
    Task<MovieDetails?> GetMovieDetails(long id);
}