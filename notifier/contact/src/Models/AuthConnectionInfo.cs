namespace contacts.Models
{
    public class AuthConnectionInfo:IAuthInfo
    {
        public AuthConnectionInfo()
        {
            this.address = Environment.GetEnvironmentVariable("AUTH_ADDRESS");
            this.port = Environment.GetEnvironmentVariable("AUTH_PORT");
        }
        public string? address { get; set; }
        public string? port { get; set; }
    }
}
