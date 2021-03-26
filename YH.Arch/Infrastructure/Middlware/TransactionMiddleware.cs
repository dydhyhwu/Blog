using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using YH.Arch.Infrastructure.Attribute;
using YH.Arch.Infrastructure.ORM;

namespace YH.Arch.Infrastructure.Middlware
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;

        public TransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var repository = context.RequestServices.GetService<Repository>();
            if (NeedTransaction(context))
            {
                await using var transaction = await repository.GetDatabase().BeginTransactionAsync();
                try
                {
                    await _next(context);
                    if (NeedRevertDataChanges(context))
                    {
                        await transaction.RollbackAsync();
                    }
                    else
                    {
                        repository.Flush();
                        await transaction.CommitAsync();
                    }
                }
                catch (System.Exception e)
                {
                    await transaction.RollbackAsync();
                    throw e;
                }
            }
            else
            {
                await _next(context);
                repository.Flush();
            }
        }

        private bool NeedRevertDataChanges(HttpContext context)
        {
            return HasAttribute<ForceRevertDataChangesAttribute>(context);
        }

        private bool NeedTransaction(HttpContext context)
        {
            return !HasAttribute<WithoutTransactionAttribute>(context);
        }

        private static bool HasAttribute<T>(HttpContext context) where T : class
        {
            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            var attribute = endpoint?.Metadata.GetMetadata<T>();
            return attribute != null;
        }

    }

    public static class TransactionMiddlewareExtension
    {
        public static IApplicationBuilder UseTransaction(this IApplicationBuilder app)
        {
            app.UseMiddleware<TransactionMiddleware>();
            return app;
        }
    }
}
