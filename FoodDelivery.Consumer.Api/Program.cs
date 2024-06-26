﻿using FoodDelivery.Data;
using FoodDelivery.Data.Repositories;
using FoodDelivery.Domain.Repositories;
using FoodDelivery.Services;
using FoodDelivery.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddDbContextPool<AppDbContext>(optionsBuilder =>
{
	var connectionString = builder.Configuration.GetConnectionString("SQLExpress");
	optionsBuilder.UseSqlServer(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Services.ApplyMigration();

app.Run();
