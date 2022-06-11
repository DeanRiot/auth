using System;
using System.ComponentModel.DataAnnotations;

namespace notifier.EF.Entity
{
    public class Communication
    {
        [Key]
        public Guid id { get; set; }
        public string method { get; set; }
        public Guid user { get; set; }
        public string status { get; set; }
        public DateTime timestamp { get; set; }
    }
}
