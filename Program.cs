
using Database;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"appSettings.json", false, true);
builder.Configuration.AddJsonFile($"appSettings.{builder.Environment.EnvironmentName}.json", false, true);
builder.Services.AddControllers();

// Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IYoutubeService, YoutubeService>();
builder.Services.AddSingleton<ICopyQueue, CopyQueue>();

// DB connection
builder.Services.AddDbContext<DefaultDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapPost("youtube", () => {});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
