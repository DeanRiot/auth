using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Notify : ControllerBase
    {
        [HttpPost]
        public void Post(Guid user_id, string MessageType)
        {

        }
    }
}
