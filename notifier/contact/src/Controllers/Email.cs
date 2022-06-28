using contacts.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using contacts.ControllersFacades;
using System;

namespace contacts.Controllers
{
    [ApiController]
    [Route("contacts/email")]
    public class Email : ControllerBase
    {
        private readonly ILogger<Email> _logger;
        EmailFacade _facade = new EmailFacade();
        public Email(ILogger<Email> logger) => _logger = logger;
       
        [HttpGet]
        public object Get(string? id)
        {
            return _facade.
        }
        [HttpPost]
        public void Post([FromBody] Contact email_data)
        {
            
        }
        [HttpPut]
        public void Put([FromBody] Contact email_data)
        {

        }
    }
}