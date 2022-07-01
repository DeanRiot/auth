namespace notify.Models.MessageTypes
{
    public class LoginInfoChange
    {
        /// <summary>
        /// Message for update user account logIn info
        /// </summary>
        /// <param name="serviceName">Service or site name</param>
        /// <param name="additionalInfo">Additional info for customize</param>
        public LoginInfoChange(string serviceName, string additionalInfo = "") =>
            message = $"Здравствуйте! Производится изменение данных входа в вашу учетную запись в сервисе {serviceName}.{additionalInfo}";
        public string message { get; private set; }
    }
}
