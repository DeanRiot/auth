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

        internal SMTPClient(Credentials credentials, Service service)
        {
            switch (service)
            {
                case Service.MailRu:
                    _client = CreateClient(credentials, "smtp.mail.ru", 465);
                    break;
                case Service.Google:
                    _client = CreateClient(credentials, "smtp.gmail.com", 587);
                    break;
                case Service.Yandex:
                    _client = CreateClient(credentials, "smtp.yandex.ru", 587);
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

        public void Send(string to, string message) =>
                            _client.Send(_from, to, null, message);

        public void SendAsync(string to, string message) =>
                            _client.SendAsync(_from, to, null, message, null);

    }
}
