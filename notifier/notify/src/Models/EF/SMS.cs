using System;
using System.ComponentModel.DataAnnotations;

namespace notify.Models.EF
{
    public class SMS
    {
        [Key]
        public Guid sms_id { get; set; }
        public Guid user_id { get; set; }
        public string phone { get; set; }
        public bool enabled { get; set; }
    }
}
