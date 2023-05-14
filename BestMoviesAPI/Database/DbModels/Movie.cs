namespace BestMoviesAPI.Database.DbModels
{
	public class Movie
	{
		public long Id { get; set; }

		public string Title { get; set; } = null!;

		public int Year { get; set; }
	}
}
