using Blog.Core.Infrastructure.Orm;
using Blog.Core.Service;
using Blog.Core.Service.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZeroSum.DependencyInjection.Attributes;
using ZeroSum.DependencyInjection.Interfaces;

namespace Blog.Core;

[StartupOrder(1000)]
public class Startup : IAppStartup
{
    public void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
    {
        // services.AddScoped<FavoriteLinkService, FavoriteLinkServiceImpl>();
        // services.AddScoped<Queries, QueriesImpl>();
        // services.AddScoped<ArticleService, ArticleServiceImpl>();
        // services.AddScoped<ICategoryService, CategoryService>();
        // services.AddScoped<ICosService, CosService>();
        // services.AddScoped<ICloudProviderService, CloudProviderService>();
        // services.AddScoped<ICloudAccountService, CloudAccountService>();
    }
}