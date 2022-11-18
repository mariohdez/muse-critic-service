using Microsoft.Extensions.DependencyInjection;
using MuseCritic.Models.Repository;
using MuseCritic.Repository;

var builder = WebApplication.CreateBuilder(args);

/*
 * Add MongoDB settings to the services container.
 */
builder.Services.Configure<MuseCriticDatabaseSettings>(builder.Configuration.GetSection("MuseCriticDatabase"));

/*
 * Add the MongoDB Album repository to the services container.
 */
builder.Services.AddSingleton<AlbumRepository>();

/*
 * Add the MongoDB Artist repository to the services container.
 */
builder.Services.AddSingleton<ArtistRepository>();

/*
 * Add the MongoDB Review repository to the services container.
 */
builder.Services.AddSingleton<ReviewRepository>();

/*
 * Add the MongoDB User repository to the services container.
 */
builder.Services.AddSingleton<UserRepository>();

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
