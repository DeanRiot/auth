using notify.Models.EF;
using notify.Models.MessageTypes;
using System;

namespace notify.Notifiers
{
    public abstract class BaseNotifier
    {
        public Guid userId { get; set; }
        public string method { get; set; }
        public string contact { get; set; }
        public IMessageType message { get; set; }
        protected string status { get; set; }

        NotifyContext _context;
        public BaseNotifier(NotifyContext context) => _context = context;
        protected void SaveToDB()
        {
            _context.Communication.Add(new Communication()
            {
                user = userId,
                method = method,
                status = status,
                timestamp = DateTime.Now,
            });
        }
        public abstract void SendAndSaveToDb(string contact, Guid userId, IMessageType message);
    }
}
