using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YH.Arch.Domain;
using YH.Arch.Infrastructure.Exception;

namespace YH.Arch.Infrastructure.Filter
{
    public class ApiResponseFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                var data = (context.Result as ObjectResult)?.Value;
                context.Result = new JsonResult(ApiResponse.Of(ResponseStatus.Success, SystemMessage.RequestSuccess, data));
                await next();
                return;
            }
            
            var messages = new List<string>();
            foreach (var item in context.ModelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    messages.Add(error.ErrorMessage);
                }
            }

            throw new BusinessException(string.Join(",", messages));
        }
    }
}
