using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using notifier.Models;

namespace notifier.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Methods : ControllerBase
    {
        [Host("*:8081")]
        [HttpGet]
        public void GetNotifyMethods(string type = null)
        {
            Response.StatusCode = 200;
            //or 401 if unauthorized
        }

        [Host("*:8081")]
        [HttpPost]
        public void SetNotifyMethod([FromBody] Method method)
        {
            Response.StatusCode = 201;
            //or 401 if unauthorized
            //or 400 if method type or data is null /type not exists /data not required regex   
        }

        [Host("*:8081")]
        [HttpPut]
        public void UpdateNotifyMethod([FromBody] Method method)
        {
            Response.StatusCode = 200;
            //or 401 if unauthorized
            //or 404 if method not found
            //or 400 if method type or data is null /type not exists /data not required regex
        }

        [Host("*:8081")]
        [HttpDelete]
        public void DeleteNotifyMethod([FromBody] Method method)
        {
            Response.StatusCode = 204;
            //or 401 if unauthorized
            //or 400 if method type or data is null 
         }
    }
}
