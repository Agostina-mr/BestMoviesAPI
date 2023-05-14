namespace BestMoviesAPI.Dtos;

public class MovieDto
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public int Year { get; set; }
    public string? Url { get; set; }
}