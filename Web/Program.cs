using Web.Interfaces;
using Web.Dtos;
using Web.Mappers;
using BLL.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DAL.Configuration.ConfigureService(builder.Services);
BLL.Configuration.ConfigureService(builder.Services);

builder.Services.AddSingleton<IMapper<Product, ProductDto>, ProductMapper>();
builder.Services.AddSingleton<IMapper<Category, CategoryDto>, CategoryMapper>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
