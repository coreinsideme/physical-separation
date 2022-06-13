// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using BLL.Interfaces;


var services = new ServiceCollection();
DAL.Configuration.ConfigureService(services);
BLL.Configuration.ConfigureService(services);

var catalogService = services.BuildServiceProvider()
    .GetService<ICatalogService>();

var productService = services.BuildServiceProvider()
    .GetService<IProductService>();

// do everything we need with those services

