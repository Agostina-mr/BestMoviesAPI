using BestMoviesAPI.Database.DbModels;
using Microsoft.EntityFrameworkCore;

namespace  BestMoviesAPI.Database
{
	public partial class MovieDataContext : DbContext, IMovieDataContext
	{
		protected readonly IConfiguration Configuration;

		public MovieDataContext(IConfiguration configuration, DbContextOptions<MovieDataContext> options)
			: base(options)
		{
			Configuration = configuration;
		}
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer(Configuration.GetConnectionString("BestMoviesDB"));

		public virtual DbSet<Director> Directors { get; set; }
		public virtual DbSet<Movie> Movies { get; set; }
		public virtual DbSet<Person> People { get; set; }
		public virtual DbSet<Ratings> Ratings { get; set; }
		public virtual DbSet<Star> Stars { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Director>(entity =>
			{
				entity
					.HasNoKey()
					.ToTable("directors");

				entity.Property(e => e.MovieId).HasColumnName("movie_id");
				entity.Property(e => e.PersonId).HasColumnName("person_id");

				entity.HasOne(d => d.Movie).WithMany()
					.HasForeignKey(d => d.MovieId)
					.OnDelete(DeleteBehavior.ClientSetNull);

				entity.HasOne(d => d.Person).WithMany()
					.HasForeignKey(d => d.PersonId)
					.OnDelete(DeleteBehavior.ClientSetNull);
			});

			modelBuilder.Entity<Movie>(entity =>
			{
				entity.ToTable("movies");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("id");
				entity.Property(e => e.Title).HasColumnName("title");
				entity.Property(e => e.Year)
					.HasColumnType("NUMERIC")
					.HasColumnName("year");
			});

			modelBuilder.Entity<Person>(entity =>
			{
				entity.ToTable("people");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("id");
				entity.Property(e => e.Birth)
					.HasColumnType("NUMERIC")
					.HasColumnName("birth");
				entity.Property(e => e.Name).HasColumnName("name");
			});

			modelBuilder.Entity<Ratings>(entity =>
			{
				entity
					.HasKey(r => r.MovieId);
				entity.ToTable("ratings");

				entity.Property(e => e.MovieId).HasColumnName("movie_id");
				entity.Property(e => e.Rating).HasColumnName("rating");
				entity.Property(e => e.Votes).HasColumnName("votes");

				entity.HasOne(d => d.Movie).WithMany()
					.HasForeignKey(d => d.MovieId)
					.OnDelete(DeleteBehavior.ClientSetNull);
			});

			modelBuilder.Entity<Star>(entity =>
			{
				entity
					.HasNoKey()
					.ToTable("stars");

				entity.Property(e => e.MovieId).HasColumnName("movie_id");
				entity.Property(e => e.PersonId).HasColumnName("person_id");

				entity.HasOne(d => d.Movie).WithMany()
					.HasForeignKey(d => d.MovieId)
					.OnDelete(DeleteBehavior.ClientSetNull);

				entity.HasOne(d => d.Person).WithMany()
					.HasForeignKey(d => d.PersonId)
					.OnDelete(DeleteBehavior.ClientSetNull);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}