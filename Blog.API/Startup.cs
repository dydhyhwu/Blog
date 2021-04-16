using Blog.Core.Infrastructure.Orm;
using Blog.Core.Service;
using Blog.Core.Service.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using YH.Arch.Infrastructure;
using YH.Arch.Infrastructure.Filter;
using YH.Arch.Infrastructure.Middlware;
using YH.Arch.Infrastructure.ORM;

namespace Blog.API
{
    public class Startup
    {
        private string Default_Cors = "All";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddMvcOptions(options => options.Filters.Add<ApiResponseFilter>())
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = Settings.JsonSerializer.ContractResolver;
                    options.SerializerSettings.DateFormatString = Settings.JsonSerializer.DateFormatString;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog.API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(Default_Cors, builder =>
                {
                    builder.SetIsOriginAllowed(x => true)
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddAutoMapper(typeof(BlogRepository).Assembly);

            #region “¿¿µ◊¢»Î

            services.AddScoped<Repository, BlogRepository>();
            services.AddDbContext<BlogContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseMySql(
                    Configuration["Db"], 
                    ServerVersion.AutoDetect(Configuration["Db"]), 
                    mysqlOptions =>
                    {
                        mysqlOptions.CharSet(CharSet.Utf8Mb4);
                    });
            });

            services.AddScoped<FavoriteLinkService, FavoriteLinkServiceImpl>();
            services.AddScoped<Queries, QueriesImpl>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog.API v1"));
            }

            app.UseExceptionCatchMiddleware();
            app.UseTransaction();
            app.UseCors(Default_Cors);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
