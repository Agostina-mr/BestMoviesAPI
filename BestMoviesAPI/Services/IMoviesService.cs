using BestMoviesAPI.Controllers;
using BestMoviesAPI.Dtos;

namespace BestMoviesAPI.Services;

public interface IMoviesService
{
    Task RateMovie(RateDto dto);
    Task<MovieDto?> GetMovie(long movieId);
}