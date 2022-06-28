using contacts.ControllersFacades;
using contacts.Models;
using contacts.Models.DTO;
using contacts.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace contacts.Controllers
{
    [ApiController]
    [Route("contacts/email")]
    public class Email : ControllerBase
    {
        private readonly ILogger<Email> _logger;
        EmailFacade _facade;
        public Email(ILogger<Email> logger, NotifyContext context, AuthConnectionInfo connection)
        {
            _logger = logger;
            _facade = new EmailFacade(context, connection);
        }


        [HttpGet]
        public void Get()
        {
            string token = GetTokenFromCookie(Request);
            Response.Clear();
            Response.StatusCode = 200;
            Response.ContentType = "application/json; charset=utf-8";
            Response.WriteAsJsonAsync(_facade.Get(token));
        }

        [HttpPost]
        public async void Post([FromBody] Contact contact)
        {
            await _facade.Insert(contact, GetTokenFromCookie(Request));
            Response.StatusCode = 200;
        }

        [HttpPut]
        public async void Put([FromBody] Contact contact)
        {
            await _facade.Update(contact, GetTokenFromCookie(Request));
            Response.StatusCode = 200;
        }
        private string GetTokenFromCookie(HttpRequest request)
        {
            try
            {
                var cookie = request.Cookies.First(c => c.Key.Equals("session"));
                return cookie.Value;
            }
            catch
            {
                return "";
            }
        }
    }
}