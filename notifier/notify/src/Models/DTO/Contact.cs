using notify.Models.EF;
using notify.Models.MessageTypes;
using System;

namespace contacts.Models.DTO
{
    public class Contact
    {
        public Guid userId { get; set; }
        public string method { get; set; }
        public string contact { get; set; }
        public IMessageType message { get; set; }
        public string status { get; set; }
    }
}
