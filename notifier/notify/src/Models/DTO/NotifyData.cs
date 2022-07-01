using notify.Models.MessageTypes;
using System;

namespace notify.Models.DTO
{
    public class NotifyData
    {
        public Guid userId { get; set; }
        public IMessageType message { get; set; }
        public string[] SmsContacts { get; set; }
        public string[] MailContacts { get; set; }
    }
}
