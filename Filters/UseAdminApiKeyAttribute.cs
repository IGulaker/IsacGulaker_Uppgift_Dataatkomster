using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IsacGulaker_Uppgift_Dataatkomster.Filters
{
    public class UseAdminApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string apiKey = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>().GetValue<string>("ApiKeys:ApiAdminAccessKey");

            if (!context.HttpContext.Request.Headers.TryGetValue("key", out var key))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apiKey.Equals(key))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
