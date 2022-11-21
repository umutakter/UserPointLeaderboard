using MallconomyCase.IRepository;
using MallconomyCase.Models;
using MallconomyCase.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

//Database Settings

builder.Services.Configure<UserPointDatabaseSettings>(
    builder.Configuration.GetSection(nameof(UserPointDatabaseSettings)));

builder.Services.AddSingleton<IUserPointDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<UserPointDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("UserPointDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IUserPointRepository, UserPointRepository>();

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
