using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using notify.Models;

namespace notify.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Methods : ControllerBase
    {
        [Host("*:8081", "*:8080")]
        [HttpGet]
        public void GetNotifyMethods(string type = null)
        {
            Response.StatusCode = 200;
        }

        [Host("*:8081", "*:8080")]
        [HttpPost]
        public void SetNotifyMethod([FromBody] Method method)
        {
            Response.StatusCode = 200;
        }

        [Host("*:8081", "*:8080")]
        [HttpPut]
        public void UpdateNotifyMethod([FromBody] Method method)
        {
            Response.StatusCode = 200;
        }
    }
}
