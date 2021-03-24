using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YH.Arch.Domain;

namespace YH.Arch.Infrastructure.Filter
{
    public class ApiResponseFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var data = (context.Result as ObjectResult)?.Value;
            context.Result = new JsonResult(ApiResponse.Of(ResponseStatus.Success, SystemMessage.RequestSuccess, data));
            await next();
        }
    }
}
