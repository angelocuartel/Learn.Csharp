using Learn.Csharp.Week2.Solution.Api.Repositories.Context;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace Learn.Csharp.Week2.Solution.Api.Filters
{
    public class BlogCacheResourceFilter : IAsyncResourceFilter
    {
        private readonly IMemoryCache _memoryCache;
        private readonly AppDbContext _appDbContext;
        public BlogCacheResourceFilter(IMemoryCache memoryCache, AppDbContext appDbContext)
        {
            _memoryCache = memoryCache;
            _appDbContext = appDbContext;
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            // get the userid from the query parameters
            // get the blogs from the memory cache if exists
            // if not exists get the blogs from the database and set it to the memory cache

            if (!context.HttpContext.Request.Query.TryGetValue("userId", out var userIdString) || !int.TryParse(userIdString, out var userId))
            {
                context.HttpContext.Response.StatusCode = 400; // Bad Request
                await context.HttpContext.Response.WriteAsync("Invalid or missing userId parameter.");
                return;
            }

            string cacheKey = $"blogs_user_{userId}";

            if (!_memoryCache.TryGetValue(cacheKey, out var blog))
            {
                // Key not in cache, so get data from database
                blog = _appDbContext.BlogsRepository.Where(b => b.UserId == userId).FirstOrDefault()?.Content;
                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                // Save data in cache
                _memoryCache.Set(cacheKey, blog, cacheEntryOptions);
            }

            context.HttpContext.Items["blog"] = blog;

            await next();

        }
    }
}
