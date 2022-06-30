using Sms.SmsSenders;
using System.Threading.Tasks;

namespace SMS
{
    public class SmsNotifier
    {
        ISmsSender _sender;
        /// <summary>
        /// ISmsSender MUST be Singletone
        /// </summary>
        /// <param name="sender"></param>
        public SmsNotifier(ISmsSender sender) => _sender = sender;
        /// <summary>
        // Send Message to abonent
        ///</summary>
        /// <param name="to">format 7xxxxxxxxxx</param>
        /// <param name="message">message text</param>
        /// <note>Use QUEUE for many send</note>
        public void Send(string to, string message) => _sender.Send(to, message);
        
        /// <summary>
        // Send Message to abonent
        ///</summary>
        /// <param name="to">format 7xxxxxxxxxx</param>
        /// <param name="message">message text</param>
        /// <note>Use QUEUE for many send</note>
        public async Task SendAsync(string to, string message) =>
                  await _sender.SendAsync(to, message);
    }
}
