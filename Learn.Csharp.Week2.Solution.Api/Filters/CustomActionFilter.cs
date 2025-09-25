using Microsoft.AspNetCore.Mvc.Filters;

namespace Learn.Csharp.Week2.Solution.Api.Filters
{
    public class CustomActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Before the action executes");

            string nameFromParameters = context.HttpContext.Request.Query["name"].ToString();

            Console.WriteLine($"Name from parameters: {nameFromParameters}");

            await next();
        }
    }
}
