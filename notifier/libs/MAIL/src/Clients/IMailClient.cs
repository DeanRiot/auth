namespace Mail.Clients
{
    public interface IMailClient
    {
        public int Send(string to, string message);
        public int SendAsync(string to, string message);
    }
}
