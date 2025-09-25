using Learn.Csharp.Week2.Solution.Api.Filters;
using Learn.Csharp.Week2.Solution.Api.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Csharp.Week2.Solution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [ServiceFilter(typeof(BlogCacheResourceFilter))]
        [HttpGet]
        public IActionResult GetPost()
        {
            var blogs = HttpContext.Items["blog"];

            var postModelResponse = new PostModelResponse("Title 1", "Content 1", blogs?.ToString() ?? string.Empty);

            return Ok(postModelResponse);
        }
    }
}
