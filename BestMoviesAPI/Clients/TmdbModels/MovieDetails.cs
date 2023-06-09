using System.Text.Json.Serialization;

namespace BestMoviesAPI.Clients.TmdbModels;

public class MovieDetails
{  
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("original_language")]
    public string? OriginalLanguage { get; set; }
    [JsonPropertyName("original_title")]
    public string? OriginalTitle { get; set; }
    [JsonPropertyName("overview")]
    public string? Overview { get; set; }
    [JsonPropertyName("popularity")]
    public double Popularity { get; set; }
    [JsonPropertyName("poster_path")] 
    public string? PosterPath { get; set; }
    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; set; }
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
}