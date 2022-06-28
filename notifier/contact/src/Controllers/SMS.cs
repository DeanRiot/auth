using Microsoft.AspNetCore.Mvc;
using System;

namespace contacts.Controllers
{
    [ApiController]
    [Route("contacts/sms")]
    public class SMS : ControllerBase
    {
        private readonly ILogger<SMS> _logger;

        public SMS(ILogger<SMS> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get(string id)
        {

        }
        [HttpPost]
        public void Post([FromBody] string phone_data)
        {

        }
        [HttpPut]
        public void Put([FromBody] string phone_data)
        {

        }
    }
}