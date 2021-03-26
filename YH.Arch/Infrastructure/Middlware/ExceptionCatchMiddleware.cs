using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using YH.Arch.Domain;

namespace YH.Arch.Infrastructure.Middlware
{
    /// <summary>
    /// 异常全局处理中间件
    /// </summary>
    public class ExceptionCatchMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionCatchMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception e)
            {
                await HandleException(context, e);
            }
        }


        private async Task HandleException(HttpContext context, System.Exception exception)
        {
            var response = context.Response;

            response.StatusCode = 200;
            response.ContentType = "application/json";
            await response.WriteAsync(JsonConvert.SerializeObject(GetResponseData(exception), new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            }));
        }

        private static ApiResponse GetResponseData(System.Exception exception)
        {
            return ApiResponse.Of(ResponseStatus.Error, exception.Message, null);
        }
    }

    public static class ExceptionCatchMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionCatchMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionCatchMiddleware>();
            return app;
        }
    }
}
