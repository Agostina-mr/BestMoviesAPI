using BestMoviesAPI.Clients.TmdbModels;

namespace BestMoviesAPI.Clients;

public class TmdbClient : ITmdbClient
{
    private readonly HttpClient _httpClient;

    public TmdbClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MovieDetails?> GetMovieDetails(long id)
    {
        var response = await _httpClient.GetAsync($"movie/tt{id}");

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MovieDetails>();
    }
}