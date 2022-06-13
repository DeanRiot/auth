namespace notifier.Models
{
    public class UpdatableEntity
    {
        public string type { get; set; }
        public Method target { get; set; }
        public Method data { get; set; }
    }
}
