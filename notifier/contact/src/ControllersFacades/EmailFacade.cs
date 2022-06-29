using contacts.Models;
using contacts.Models.DTO;
using contacts.Models.EF;

namespace contacts.ControllersFacades
{
    public class EmailFacade : BaseControllerFacade
    {
        public EmailFacade(NotifyContext context, IAuthInfo auth_service_address)
                                      : base(context, auth_service_address) { }

        public override async Task Delete(Contact contact, string user_token)
        {
            var user_id = GetUserId(user_token);
            if (!user_id.Equals(Guid.Empty)) await DropContact(contact);
            else return;
        }

        private async Task DropContact(Contact contact)
        {
            var entrie = _context.MAIL.FirstOrDefault(m => m.mail_id.Equals(contact.contactId));
            if (entrie is not null) _context.Remove(entrie);
            await _context.SaveChangesAsync();
        }

        public override List<Contact> Get(string user_token)
        {
            var user_id = GetUserId(user_token);
            if (!user_id.Equals(Guid.Empty)) return GetContactsList(user_id);
            else return new List<Contact>(0);
        }

        private List<Contact> GetContactsList(Guid user_id)
        {
            List<Contact> contacts = new List<Contact>();
            List<MAIL> entries = GetEntries(user_id);
            foreach (MAIL e in entries) contacts.Add(new Contact()
            {
                contact = e.mail,
                active = e.enabled,
                contactId = e.mail_id
            }) ;
            return contacts;
        }

        private List<MAIL> GetEntries(Guid user_id) =>
                (List<MAIL>)_context.MAIL.Where(m => m.user_id.Equals(user_id));

        public override async Task Insert(Contact contact, string user_token)
        {
            var user_id = GetUserId(user_token);
            if (!user_id.Equals(Guid.Empty)) await InsertMail(contact, user_id);
            else return;
        }

        private async Task InsertMail(Contact contact,Guid user_id)
        {
            _context.MAIL.Add(new MAIL() { 
                user_id = user_id,
                mail = contact.contact,
                enabled = contact.active
            });
            await _context.SaveChangesAsync();
        }

        public override async Task Update(Contact contact, string user_token)
        {
            var user_id = GetUserId(user_token);
            if (!user_id.Equals(Guid.Empty)) await UpdateMail(contact, user_id);
            else return;
        }

        private async Task UpdateMail(Contact contact, Guid user_id)
        {
            _context.Update(new MAIL()
            {
                enabled = contact.active,
                mail_id = (Guid)contact.contactId,
                mail = contact.contact,
                user_id = user_id
            });
            await _context.SaveChangesAsync();
        }
    }
}
