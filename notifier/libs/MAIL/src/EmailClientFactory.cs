using Mail.ConfigEnums;

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
        public Client Create() => new Client(_credentials, _service);

    }
}