using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Data.Repositories;
using Room2_NorthwindAPI.Models;
using Room2_NorthwindAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var dbConnection = builder.Configuration["DefaultConnection"];


//Add services to the container.
builder.Services.AddDbContext<NorthwindContext>(
opt => opt.UseSqlServer(dbConnection));



builder.Services.AddControllers()
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(INorthwindRepository), typeof(NorthwindRepository));
//builder.Services.AddScoped(typeof(INorthwindService<>), typeof(NorthwindService<>));
//builder.Services.AddScoped<INorthwindRepository<Supplier>, SuppliersRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
