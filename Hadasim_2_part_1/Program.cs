using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<TodoContextPatient>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<TodoContextVaccination>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<TodoContextPositive>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<TodoContextNegative>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDbContext<TodoContextCompany_Vaccine>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
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
