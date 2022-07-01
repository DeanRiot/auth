namespace notify.Models.MessageTypes
{
    public class AccountRegistration : IMessageType
    {
        /// <summary>
        /// Message for User Registration
        /// </summary>
        /// <param name="serviceName">Service or site name</param>
        /// <param name="serviceInfo">Additional info for customize</param>
        public AccountRegistration(string serviceName, string serviceInfo = "") =>
                        message = $"Здравствуйте! Произведена регистрация в сервисе {serviceName}.{serviceInfo}";
        public string message { get; private set; }
    }
}
