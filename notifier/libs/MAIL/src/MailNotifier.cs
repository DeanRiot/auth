using Mail.Clients;

namespace Mail
{
    public class MailNotifier
    {
        IMailClient _sender;
        /// <summary>
        /// ISmsSender instance MUST be Singletone
        /// </summary>
        /// <param name="sender"></param>
        public MailNotifier(IMailClient sender) => _sender = sender;
        /// <summary>
        // Send Message to mail
        ///</summary>
        /// <param name="to">format test@mail.xxx</param>
        /// <param name="message">message text</param>
        /// <note>Use QUEUE for many send</note>
        public int Send(string to, string message) => _sender.Send(to, message);

        /// <summary>
        // Send Message to abonent
        ///</summary>
        /// <param name="to">format test@mail.xxx</param>
        /// <param name="message">message text</param>
        /// <note>Use QUEUE for many send</note>
        public int SendAsync(string to, string message) => _sender.SendAsync(to, message);
    }
}
