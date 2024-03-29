using BLL.Entities;
using Web.Dtos;
using Web.Interfaces;
using Web.Mappers;
using Web.Middlewares;
using Web.Models;
using Web.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DAL.Configuration.ConfigureService(builder.Services);
BLL.Configuration.ConfigureService(builder.Services);

builder.Services.AddSingleton<IMapper<Product, ProductDto>, ProductMapper>();
builder.Services.AddSingleton<IMapper<Category, CategoryDto>, CategoryMapper>();
builder.Services.AddSingleton<IRabbitMQProducer, RabbitMQProducer>();

builder.Services.Configure<RabbitMQConfiguration>(builder.Configuration.GetSection(RabbitMQConfiguration.SectionName));

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<CorrelationIdMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
