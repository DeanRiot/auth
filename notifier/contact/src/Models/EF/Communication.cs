using System.ComponentModel.DataAnnotations;

namespace contacts.Models.EF
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
