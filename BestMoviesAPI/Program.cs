using System.Net.Http.Headers;
using BestMoviesAPI.Clients;
using BestMoviesAPI.Database;
using BestMoviesAPI.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BestMoviesDB");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddDbContext<IMovieDataContext, MovieDataContext>(options => options.UseSqlServer(connectionString))
    .AddScoped<IMoviesService, MoviesService>()
    .AddHttpClient<ITmdbClient, TmdbClient>(client =>
    {
        client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", builder.Configuration["TmdbKey"]);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/MovieMinimalAPIExample", (long id, IMoviesService service) => service.GetMovie(id));

app.Run();
