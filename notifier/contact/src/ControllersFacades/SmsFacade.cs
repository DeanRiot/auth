using contacts.Models;
using contacts.Models.DTO;
using contacts.Models.EF;

namespace contacts.ControllersFacades
{
    public class SmsFacade : BaseControllerFacade
    {
        public SmsFacade(NotifyContext context, IAuthInfo auth_service_address) 
                                    : base(context, auth_service_address){}

        public async override Task Delete(Contact contact, string user_token)
        {
            var user_id = GetUserId(user_token);
            if (!user_id.Equals(Guid.Empty))
            {
                _context.SMS.Remove(new SMS()
                {
                    user_id = user_id,
                    phone = contact.contact,
                    sms_id = (Guid)contact.contactId
                });
                await _context.SaveChangesAsync();
            }
            else return;  
        }

        public override List<Contact> Get(string user_token)
        {
            var user_id = GetUserId(user_token);
            if (!user_id.Equals(Guid.Empty)) return MakeSmsList(user_id);
            else return new List<Contact>(0);
        }

        private List<Contact> MakeSmsList(Guid user)
        {
            List<Contact> contacts = new List<Contact>();
            var entries = GetEntriesList(user);
            foreach (SMS e in entries) contacts.Add(new Contact()
            {
                contactId = e.sms_id,
                contact = e.phone,
                active = e.enabled
            }) ;
            return contacts;
        }

        private List<SMS> GetEntriesList(Guid user)=>
                (List<SMS>)_context.SMS.Where(s=>s.user_id.Equals(user));
        
        public async override Task Insert(Contact contact, string user_token)
        {
            var user_id = GetUserId(user_token);
            if (!user_id.Equals(Guid.Empty)) await InsertContact(contact, user_token);
            else return;
        }

        private async Task InsertContact(Contact contact, string user_token)
        {
            _context.Add(new SMS()
            {
                phone = contact.contact,
                enabled = contact.active
            });
            await _context.SaveChangesAsync();
        }

        public async override Task Update(Contact contact, string user_token)
        {
            var user_id = GetUserId(user_token);
            if (!user_id.Equals(Guid.Empty)) await UpdateContact(contact, user_id);
            else return;
        }

        private async Task UpdateContact(Contact contact, Guid user_id)
        {
            _context.Update(new SMS()
            {
                enabled = contact.active,
                sms_id = (Guid)contact.contactId,
                phone = contact.contact,
                user_id = user_id
            });
            await _context.SaveChangesAsync();
        }
    }
}
