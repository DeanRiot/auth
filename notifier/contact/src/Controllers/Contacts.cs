using contacts.ControllersFacades;
using contacts.Models;
using contacts.Models.DTO;
using contacts.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace contacts.Controllers
{
    [ApiController]
    [Route("contact")]
    public class Contacts : ControllerBase
    {
        BaseControllerFacade[] _controllersFacades = new BaseControllerFacade[2];
        private readonly ILogger<Contacts> _logger;
        public Contacts(ILogger<Contacts> logger, NotifyContext context, AuthConnectionInfo connection)
        {
            _logger = logger;
            _controllersFacades[0] = new SmsFacade(context, connection);
            _controllersFacades[0] = new EmailFacade(context, connection);
        }

        [HttpDelete]
        public void Delete(Guid contact_id)
        {
            foreach(BaseControllerFacade f in _controllersFacades)
            {
                f.Delete(new Contact { contactId = contact_id }, GetTokenFromCookie(Request));
            }
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
