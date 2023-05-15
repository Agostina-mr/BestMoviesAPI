namespace  BestMoviesAPI.Database.DbModels
{
	public class Ratings
	{
		public long MovieId { get; set; }

		public float Rating { get; set; }

		public long Votes { get; set; }

		public virtual Movie Movie { get; set; } = null!;
	}
}
