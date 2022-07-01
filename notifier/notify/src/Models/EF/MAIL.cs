﻿using System;
using System.ComponentModel.DataAnnotations;

namespace notify.Models.EF
{
    public class MAIL
    {
        [Key]
        public Guid mail_id { get; set; }
        public Guid user_id { get; set; }
        public string mail { get; set; }
        public bool enabled { get; set; }
    }
}
