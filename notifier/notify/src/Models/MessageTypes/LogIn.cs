using System;

namespace notify.Models.MessageTypes
{
    public class LogIn : IMessageType
    {
        /// <summary>
        /// User Login notify text template
        /// </summary>
        /// <param name="deviceName">The device from which you logged in to your user account</param>
        /// <param name="proposedActions">Suggested actions if the login is not made by a user (not reqired)</param>
        public LogIn(string deviceName, string proposedActions = "") => message += deviceName;
        public string message { get; private set; } =
            $"Здравствуйте! {DateTime.Now} произведен вход с устройства:";
    }
}
