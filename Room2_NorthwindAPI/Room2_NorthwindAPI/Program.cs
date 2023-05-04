using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Models;

var builder = WebApplication.CreateBuilder(args);

var dbConnection = builder.Configuration["DefaultConnection"];

builder.Services.AddDbContext<NorthwindContext>(
opt => opt.UseSqlServer(dbConnection));

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
