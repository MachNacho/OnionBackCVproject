using Application.Services;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IHobbyRepository, HobbyRepository>();
builder.Services.AddScoped<IHobbyService, HobbyService>();

//Add db context and configure it
builder.Services.AddDbContext<ApplicationDbContext>(Options => { Options.UseSqlServer(builder.Configuration.GetConnectionString("HomeConnection")); });
//builder.Services.AddDbContext<ApplicationDbContext>(Options => { Options.UseSqlServer(builder.Configuration.GetConnectionString("WorkConnection"),b=>b.MigrationsAssembly("Infrastructure")); });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
