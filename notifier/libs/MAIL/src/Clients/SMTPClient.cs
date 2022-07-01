using Mail.ConfigEnums;
using Mail.Data;
using System.Net;
using System.Net.Mail;

namespace Mail.Clients
{
    internal class SMTPClient : IMailClient
    {
        SmtpClient _client;
        string _from;
        bool _undefinedClient = false;

        internal SMTPClient(Credentials credentials, Service service)
        {
            switch (service)
            {
                case Service.MailRu:
                    _client = CreateClient(credentials, "smtp.mail.ru", 465);
                    _undefinedClient = false;
                    break;
                case Service.Google:
                    _client = CreateClient(credentials, "smtp.gmail.com", 587);
                    _undefinedClient = false;
                    break;
                case Service.Yandex:
                    _client = CreateClient(credentials, "smtp.yandex.ru", 587);
                    _undefinedClient = false;
                    break;
                case Service.Undefined:
                    _undefinedClient = true;
                    break;

            }
            _from = credentials.Login;
        }

        private SmtpClient CreateClient(Credentials credentials, string host, int port)
        {
            SmtpClient client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(credentials.Login, credentials.Password),
                EnableSsl = true
            };
            return client;
        }

        /// <summary>
        /// Send data to abonent
        /// </summary>
        /// <param name="to">signature: test@mail.xxx</param>
        /// <param name="message">message text</param>
        /// <returns>0 if send success or -1 if fail</returns>
        public int Send(string to, string message)
        {
            if (_undefinedClient) return -1;
            try
            {
                _client.Send(_from, to, null, message);
                return 0;
            }
            catch { return -1; }

        }

        /// <summary>
        /// Send data to abonent
        /// </summary>
        /// <param name="to">signature: test@mail.xxx</param>
        /// <param name="message">message text</param>
        /// <returns>0 if send success or -1 if fail</returns>
        public int SendAsync(string to, string message)
        {
            if (_undefinedClient) return -1;
            try
            {
                _client.SendAsync(_from, to, null, message, null);
                return 0;
            }
            catch { return -1; }
        }


    }
}
