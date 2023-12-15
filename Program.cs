using Microsoft.EntityFrameworkCore;
using HomeControlApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LightsContextContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LightsContextContext") ?? throw new InvalidOperationException("Connection string 'LightsContextContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<TodoContext>(opt =>
//     opt.UseInMemoryDatabase("TodoList"));
    
//MySQL connection context
builder.Services.AddDbContext<LightsContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("LightConnection")));


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


