using Microsoft.Extensions.DependencyInjection;
using MuseCritic.Models.DataStore;
using MuseCritic.Repository;

var builder = WebApplication.CreateBuilder(args);

/*
 * Add MongoDB settings to the services container.
 * 
 * 
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));
 * 
 * 
 */
builder.Services.Configure<MuseCriticDatabaseSettings>(builder.Configuration.GetSection("MuseCriticDatabase"));

/*
 * Add the MongoDB Album repository to the services container.
 */
builder.Services.AddSingleton<AlbumRepository>();

// Add services to the container.
builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
