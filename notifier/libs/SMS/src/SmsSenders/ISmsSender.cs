namespace Sms.SmsSenders
{
    public interface ISmsSender
    {
        public void Send(string to, string message);
        public void SendAsync(string to, string message);
    }
}
