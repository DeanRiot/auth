namespace contacts.Models
{
    public interface IAuthInfo
    {
        string address { get; set; }
        string? port { get; set; }
    }
}
