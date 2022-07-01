using Microsoft.AspNetCore.Mvc;
using notify.Models.ConfigDTO;
using notify.Models.EF;
using System;

namespace notify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Notify : ControllerBase
    {
        QueueFacade _queueFacade;
        public Notify(NotifyContext context,ConfigInfo config) 
        {
            _queueFacade = new QueueFacade(context, config); 
        }

        [HttpPost]
        public void Post(Guid user_id, string MessageType)
        {

        }
    }
}
