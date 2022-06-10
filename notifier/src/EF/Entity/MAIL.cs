using Microsoft.EntityFrameworkCore;
using System;

namespace notifier.EF.Entity
{
    [Keyless]
    public class MAIL
    {
        public Guid user_id { get; set; }
        public string mail { get; set; }
        public bool enabled { get; set; }
    }
}
