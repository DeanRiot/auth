using Mail.Data;
using Mail.ConfigEnums;

namespace notify.Models.ConfigDTO
{
    public struct MailData
    {
        public Credentials credentials { get; private set; }
        public Service service { get; private set; }
        public MailData(string Login, string Password, string Service)
        {
            this.credentials = new Credentials(Login, Password);
            this.service = ChoiseService(Service);
        }

        private static Service ChoiseService(string service)
        {
            switch (service.ToUpper())
            {
                case "MAILRU": return Service.MailRu;
                case "GOOGLE": return Service.Google;
                case "YANDEX": return Service.Yandex;
                default: return Service.Undefined;
            }
        }
    }
}
