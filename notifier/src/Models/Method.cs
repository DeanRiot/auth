namespace notifier.Models
{
    #nullable enable
    public class Method
    {
        public string type { get; set; }
        public string data { get; set; }
        public bool enabled { get; set; } = false;
    }
}
