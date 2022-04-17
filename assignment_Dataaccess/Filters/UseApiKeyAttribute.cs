using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace assignment_Dataaccess.Filters
{
    public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Get Key from Appsettings.json
            var _config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = _config.GetValue<string>("UserApiKey");


            if (!context.HttpContext.Request.Query.TryGetValue("code", out var code))
              {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apiKey.Equals(code))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();

        }
    }
}
