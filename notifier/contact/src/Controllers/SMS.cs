using contacts.ControllersFacades;
using contacts.Models;
using contacts.Models.DTO;
using contacts.Models.EF;
using Microsoft.AspNetCore.Mvc;
using System;

namespace contacts.Controllers
{
    [ApiController]
    [Route("contacts/sms")]
    public class SMS : ControllerBase
    {
        private readonly ILogger<SMS> _logger;

        BaseControllerFacade _facade;
        public SMS(ILogger<SMS> logger,NotifyContext context, AuthConnectionInfo connection)
        {
            _logger = logger;
            _facade = new SmsFacade(context,connection); 
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
        public void Post([FromBody] Contact contact)
        {
            _facade.Insert(contact, GetTokenFromCookie(Request));
            Response.StatusCode = 200;
        }
        [HttpPut]
        public void Put([FromBody] Contact contact)
        {
            _facade.Update(contact, GetTokenFromCookie(Request));
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