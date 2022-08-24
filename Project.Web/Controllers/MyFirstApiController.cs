using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFirstApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(new string[] { "Hello", "World" });
        }

    }
}
