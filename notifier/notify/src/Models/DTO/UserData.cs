using System;

namespace notify.Models.DTO
{
    public class UserData
    {
        Guid userId { get; set; }
        string[] SmsContacts { get; set; }
        string[] MailContacts { get; set; }
    }
}
