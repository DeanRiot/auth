using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using notifier.Models;

namespace notifier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Notify : Controller
    {
        [Host("*:7071")]
        [HttpPost]
        public void NotifyUser([FromBody] Message input)
        {
            Response.StatusCode = 200;
            //or 404 if user notifications not exists
        }
    }
}
