using APIOnion.Application.Interfaces.Repositories;
using APIOnion.Application.Mapping;
using APIOnion.Application.ServiceRegistration;
using APIOnion.Persistance.Context;
using APIOnion.Persistance.Repositories;
using APIOnion.Persistance.ServiceRegistration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.ApplicationServiceRegistration();

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
