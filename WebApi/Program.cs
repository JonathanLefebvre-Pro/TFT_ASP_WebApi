using System.Data.Common;
using AppCore.Interfaces.Repositories;
using Infrastructure.Services;
using Microsoft.Data.SqlClient;
using Scalar.AspNetCore;

string connectionString =
    @"Data Source=JONATHAN\DATAVIZ;Initial Catalog=ASP_WebApi;Integrated Security=True;Trust Server Certificate=True";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DbConnection>(db => new SqlConnection(connectionString));
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
