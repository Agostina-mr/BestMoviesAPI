using BestMoviesAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using BestMoviesAPI.Services;

namespace BestMoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private IMoviesService moviesService;

    public MovieController(IMoviesService moviesService)
    {
        this.moviesService = moviesService;
    }

    [HttpPost("Rate")]
    public async Task<OkResult> RateMovie([FromBody] RateDto dto)
    {
        await moviesService.RateMovie(dto);
        return Ok();
    }

    [HttpGet("Details")]
    public async Task<MovieDto?> GetMovie(long movieId)
    {
        return await moviesService.GetMovie(movieId);
    }
}