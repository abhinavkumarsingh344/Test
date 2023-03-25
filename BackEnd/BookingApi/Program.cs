using BookingApi.Context;
using BookingApi.Repository;
using BookingApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddCors();
builder.Services.AddScoped<ICartRepository, CartRepository>();
string localSQLConnectonString = builder.Configuration.GetConnectionString("LocaldatabaseConnection");
builder.Services.AddDbContext<CartDbContext>(p => p.UseSqlServer(localSQLConnectonString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
