using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace notifier.EF.Entity
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
