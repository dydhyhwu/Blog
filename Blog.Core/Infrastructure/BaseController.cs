using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Infrastructure
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController : ControllerBase
    {
    }
}
