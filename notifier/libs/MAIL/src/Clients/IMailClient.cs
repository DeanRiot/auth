namespace Mail.Clients
{
    public interface IMailClient
    {
        public void Send(string to, string message);
        public void SendAsync(string to, string message);
    }
}
