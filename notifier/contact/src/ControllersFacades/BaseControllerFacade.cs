using contacts.Models.DTO;
using contacts.Models.EF;

namespace contacts.ControllersFacades
{
    public abstract class BaseControllerFacade
    {
        IEfProvider _provider;
        public BaseControllerFacade(IEfProvider provider) => _provider = provider;
        public virtual void Delete(Guid id, string user)
        {

        }
        public abstract Contact Get();
        public abstract void Update(Contact contact, string user_id);
        public abstract void Insert(Contact contact, string user_id);
    }
}
