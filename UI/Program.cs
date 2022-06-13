// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using BLL.Interfaces;
using BLL.Entities;


var services = new ServiceCollection();
DAL.Configuration.ConfigureService(services);
BLL.Configuration.ConfigureService(services);

var categoryService = services.BuildServiceProvider()
    .GetService<ICategoryService>();

var productService = services.BuildServiceProvider()
    .GetService<IProductService>();

// do everything we need with those services
categoryService.Add(new Category("Hats") { Image = new Uri("http://www.github.com"), ParentCategory = "Clothes" });
var category = categoryService.Get("Hats");
Console.WriteLine($"name: {category.Name}, image: {category.Image}, parent: {category.ParentCategory}");
Console.ReadKey();
