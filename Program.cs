using FluentValidation;
using MarketMgr.DataAccess.Data;
using MarketMgr.DataAccess.Entities;
using MarketMgr.Endpoints;
using MarketMgr.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddDbContext<MarketMgrDbContext>(
    opt => opt.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

var app = builder.Build();

app.MapProductEndpoints();

app.UseHttpsRedirection();

app.Run();