using notify.Models.EF;
using notify.Models.MessageTypes;
using System;

namespace notify.Notifiers
{
    public class EmailNotifier : BaseNotifier
    {
        Mail.MailNotifier _notifier;
        public EmailNotifier(NotifyContext context, Mail.Data.Credentials credentials, Mail.ConfigEnums.Service service) : base(context)
        {
            var factory = new Mail.EmailClientFactory(credentials, service);
            _notifier = (Mail.MailNotifier)factory.Create();
        }
        public override void SendAndSaveToDb(string contact, Guid userId, IMessageType message)
        {
            this.contact = contact;
            this.userId = userId;
            this.message = message;
            this.status = _notifier.Send(this.contact, this.message.message) == 0 ? "SUCCESS" : "Fail";
            SaveToDB();
        }
    }
}
