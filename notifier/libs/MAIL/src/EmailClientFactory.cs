using Mail.Clients;
using Mail.ConfigEnums;
using Mail.Data;

namespace Mail
{
    public class EmailClientFactory
    {
        Credentials _credentials;
        Service _service;
        public EmailClientFactory(Credentials credentials, Service service)
        {
            _credentials = credentials;
            _service = service;
        }
        public IMailClient Create() => new SMTPClient(_credentials, _service);

    }
}