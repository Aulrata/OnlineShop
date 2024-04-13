using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Services;
using OnlineShop.Domain.Abstractions;
using OnlineShop.Domain.Contracts;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineShopDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQL"));
    });

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

