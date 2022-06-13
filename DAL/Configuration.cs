using Microsoft.Extensions.DependencyInjection;

using BLL.Interfaces;
using DAL.Repositories;
using DAL.Interfaces;
using DAL.Services;

namespace DAL
{
    public static class Configuration
    {
        public static void ConfigureService(this ServiceCollection services)
        {
            services
                .AddSingleton<ICategoryRepository, CategoryRepository>()
                .AddSingleton<IProductRepository, ProductRepository>()
                .AddSingleton<ICommandExecutor, CommandExecutor>()
                .AddSingleton<IConnectionProvider, ConnectionProvider>();
        }
    }
}