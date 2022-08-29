using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IsacGulaker_Uppgift_Dataatkomster.Filters
{
    public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string apiAccessKey = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>().GetValue<string>("ApiKeys:ApiAccessKey");

            if (!context.HttpContext.Request.Query.TryGetValue("key", out var key))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apiAccessKey.Equals(key))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
