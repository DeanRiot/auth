using notify.Models.EF;
using Microsoft.AspNetCore.Mvc;
using System;

namespace notify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Notify : ControllerBase
    {
        public Notify(NotifyContext context) { }

        [HttpPost]
        public void Post(Guid user_id, string MessageType)
        {

        }
    }
}
