using contacts.Models.DTO;
using contacts.Models.EF;

namespace contacts.ControllersFacades
{
    public class SmsFacade : BaseControllerFacade
    {
        public SmsFacade(IEfProvider provider) : base(provider)
        {
        }

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
