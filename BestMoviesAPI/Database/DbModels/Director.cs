namespace  BestMoviesAPI.Database.DbModels
{
	public class Director
	{
		public long MovieId { get; set; }

		public long PersonId { get; set; }

		public virtual Movie Movie { get; set; } = null!;

		public virtual Person Person { get; set; } = null!;
	}
}
