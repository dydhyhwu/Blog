using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZeroSum.App.Extensions;
using ZeroSum.App.Middlewares;
using ZeroSum.DependencyInjection.Attributes;
using ZeroSum.DependencyInjection.Extensions;
using ZeroSum.DependencyInjection.Interfaces;
using ZeroSum.Extend.Cors;
using ZeroSum.Extend.EFCore.MySql;
using ZeroSum.Extend.Mapper;
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
        services.AddCorsSupported(configuration);
        services.AddEFCore(configuration);
        services.AddSwaggerDoc(configuration);
        services.AddAutoMapper();
        services.AddDependencyInjection(ServiceLifetime.Scoped);
    }

    public void Configuration(IApplicationBuilder app)
    {
        // 全局异常处理
        app.EnableExceptionHandler();

        // 自动提交数据库改动
        app.EnableAutoSave();

        // 自动映射
        app.UseAutoMapper();

        app.UseCorsSupported();
        app.UseSwaggerDoc();

        app.UseRouting();

        // app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}