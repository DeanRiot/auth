using notify.Models.EF;
using notify.Models.MessageTypes;
using System;

namespace notify.Notifiers
{
    public class MailNotifier : BaseNotifier
    {
        Mail.MailNotifier _notifier;
        public MailNotifier(NotifyContext context, Mail.Data.Credentials credentials, Mail.ConfigEnums.Service service) : base(context)
        {
            var factory = new Mail.EmailClientFactory(credentials, service);
            _notifier = (Mail.MailNotifier)factory.Create();
        }
        public void SendAndSaveToDb(string contact, Guid userId, IMessageType message)
        {
            this.contact = contact;
            this.userId = userId;
            this.message = message;

            _notifier.Send(this.contact, this.message.message);
            SaveToDB();
        }
    }
}
