namespace contacts.Models
{
    public struct AuthConnectionInfo
    {
        public AuthConnectionInfo(string address, string? port=null)
        {
            this.address = address;
            this.port = port;
        }
        public string address { get; set; }
        public string? port { get; set; }
    }
}
