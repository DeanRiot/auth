using contacts.Models.DTO;
using contacts.Models.EF;

namespace contacts.ControllersFacades
{
    public class EmailFacade : BaseControllerFacade
    {
        public EmailFacade(IEfProvider provider) : base(provider) { }

        public override Contact Get()
        {
            throw new NotImplementedException();
        }

        public override void Insert(Contact contact, string user_id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Contact contact, string user_id)
        {
            throw new NotImplementedException();
        }
    }
}
