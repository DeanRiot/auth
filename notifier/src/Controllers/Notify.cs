using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using notify.Models;

namespace notify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Notify : Controller
    {
        [Host("*:7071", "*:7070")]
        [HttpPost]
        public void NotifyUser([FromBody] Message input)
        {
            Response.StatusCode = 200;
        }
    }
}
