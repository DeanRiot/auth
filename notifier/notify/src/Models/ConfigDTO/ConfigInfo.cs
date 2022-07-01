using notify.Models.EF;

namespace notify.Models.ConfigDTO
{
    public class ConfigInfo
    {
        public MailData mailData { get; private set; }
        public string smsComPort { get; private set; }
        public ConfigInfo(MailData mail, string com_port=null)
        {
            mailData = mail;
            smsComPort = com_port;
        }
    }
}
