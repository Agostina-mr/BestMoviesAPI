﻿namespace  BestMoviesAPI.Database.DbModels
{
	public partial class Star
	{
		public long MovieId { get; set; }

		public long PersonId { get; set; }

		public virtual Movie Movie { get; set; } = null!;

		public virtual Person Person { get; set; } = null!;
	}
}
