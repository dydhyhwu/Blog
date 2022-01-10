using Blog.Core.Infrastructure.Orm;
using Blog.Core.Service;
using Blog.Core.Service.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZeroSum.App.Extensions;
using ZeroSum.App.Middlewares;
using ZeroSum.DependencyInjection.Attributes;
using ZeroSum.DependencyInjection.Interfaces;
using ZeroSum.Extend.EFCore.MySql;
using ZeroSum.Extend.Swagger;

namespace Blog.Core;

[StartupOrder(1000)]
public class Startup : IAppStartup
{
    public void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDistributedMemoryCache();
        
        services.AddHttpContextAccessor();
        services.AddControllers().AddFriendlyResponse();
        services.AddCors();
        services.AddEFCore(configuration);
        services.AddSwaggerDoc(configuration);
        services.AddScoped<FavoriteLinkService, FavoriteLinkServiceImpl>();
        services.AddScoped<Queries, QueriesImpl>();
        services.AddScoped<ArticleService, ArticleServiceImpl>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICosService, CosService>();
        services.AddScoped<ICloudProviderService, CloudProviderService>();
        services.AddScoped<ICloudAccountService, CloudAccountService>();
    }

    public void Configuration(IApplicationBuilder app)
    {
        // 全局异常处理
        app.EnableExceptionHandler();

        // 自动提交数据库改动
        // app.EnableAutoSave();

        app.UseCors();
        app.UseSwaggerDoc();

        app.UseRouting();

        // app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}