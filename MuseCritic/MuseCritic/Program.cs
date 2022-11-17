using MuseCritic.Models.DataStore;

var builder = WebApplication.CreateBuilder(args);

/*
 * Add MongoDB to the services container.
 */
builder.Services.Configure<MuseCriticDatabaseSettings>(builder.Configuration.GetSection("MuseCriticDatabase"));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
