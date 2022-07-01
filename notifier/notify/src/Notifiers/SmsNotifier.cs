using notify.Models.EF;
using notify.Models.MessageTypes;
using Sms.SmsSenders;
using System;

namespace notify.Notifiers
{
    public class SmsNotifier : BaseNotifier
    {
        SMS.SmsNotifier _notifier;
        public SmsNotifier(NotifyContext context, string port) : base(context)
        {
            _notifier = new SMS.SmsNotifier(new SerialSender(port));
            this.method = "SMS";
            this.status = "FAIL";
        }

        public override void SendAndSaveToDb(string contact, Guid userId, IMessageType message)
        {
            this.contact = contact;
            this.userId = userId;
            this.message = message;

            _notifier.Send(this.contact, this.message.message);
            SaveToDB();
        }
    }
}
