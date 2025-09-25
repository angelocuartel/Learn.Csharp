namespace Learn.Csharp.Week2.Solution.Api.CustomMiddlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;


        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public  async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("please check your parameters.");

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
            }
            catch(Exception ex)
            {
                _logger.LogError("An exception occurs");

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
            }
        }
    }
}
