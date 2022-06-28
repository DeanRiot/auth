using Microsoft.AspNetCore.Mvc;

namespace contacts.Controllers
{
    [ApiController]
    [Route("contact")]
    public class Contacts : ControllerBase
    {
        [HttpDelete]
        public void Delete(Guid contact_id)
        {

        }
    }
}
