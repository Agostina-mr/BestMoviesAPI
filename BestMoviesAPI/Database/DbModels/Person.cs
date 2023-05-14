namespace  BestMoviesAPI.Database.DbModels
{
	public partial class Person
	{
		public long Id { get; set; }

		public string Name { get; set; } = null!;

		public int Birth { get; set; }
	}
}
