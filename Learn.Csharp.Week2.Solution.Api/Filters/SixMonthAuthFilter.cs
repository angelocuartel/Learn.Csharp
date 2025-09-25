using Learn.Csharp.Week2.Solution.Api.Repositories.Context;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Learn.Csharp.Week2.Solution.Api.Filters
{

    public class SixMonthAuthFilter : IAsyncAuthorizationFilter
    {
        private readonly AppDbContext _appDbContext;

        public SixMonthAuthFilter(AppDbContext appDbContext) => _appDbContext = appDbContext;
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("username", out var username) ||
                !context.HttpContext.Request.Headers.TryGetValue("password", out var password))
            {
                context.HttpContext.Response.StatusCode = 401; // Unauthorized
                return Task.CompletedTask;
            }

            var user = _appDbContext.UsersRepository.FirstOrDefault(u => u.UserName == username && u.Password == password);

            bool accountIsSixMonthsOldAndBeyond =  user?.DateCreated.Date <= DateTime.Now.Date.AddMonths(-6);

            if (!accountIsSixMonthsOldAndBeyond)
            {
                context.HttpContext.Response.StatusCode = 401; // Unauthorized
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
