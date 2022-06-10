using Microsoft.EntityFrameworkCore;
using System;

namespace notifier.EF.Entity
{
    [Keyless]
    public class SMS
    {
        public Guid user_id { get; set; }
        public string phone { get; set; }
        public bool enabled { get; set; }
    }
}
