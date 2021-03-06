using Sms.SmsSenders;

namespace SMS
{
    public class SmsNotifier
    {
        ISmsSender _sender;
        /// <summary>
        /// ISmsSender instance MUST be Singletone
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
        public void SendAsync(string to, string message) => _sender.SendAsync(to, message);
    }
}
