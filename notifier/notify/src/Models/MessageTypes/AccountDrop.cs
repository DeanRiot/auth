namespace notify.Models.MessageTypes
{
    public class AccountDrop : IMessageType
    {
        /// <summary>
        /// Message for delete user account
        /// </summary>
        /// <param name="serviceName">Service or site name</param>
        /// <param name="additionalInfo">Additional info for customize</param>
        public AccountDrop(string serviceName, string additionalInfo = "") =>
            message = $"Здравствуйте! Производится удаление Вашей учетной записи в сервисе {serviceName}.{additionalInfo}";
        public string message { get; private set; }
    }
}
