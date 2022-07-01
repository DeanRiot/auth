using notify.Models.ConfigDTO;
using notify.Models.DTO;
using notify.Models.EF;
using notify.Notifiers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace notify
{
    public class QueueFacade
    {
        NotifyContext _context;
        ConfigInfo _configData;
        public QueueFacade(NotifyContext context, ConfigInfo config)
        {
            _context = context;
            _configData = config;
        }
        ConcurrentQueue<SmsNotifier> _SmsQueue = new ConcurrentQueue<SmsNotifier>();
        ConcurrentQueue<EmailNotifier> _EMailQueue = new ConcurrentQueue<EmailNotifier>();
        public async void AddToQueues(NotifyData data)
        {
            await Task.Run(() =>
            {
                foreach (SmsNotifier notifier in GetSmsContactsList(data)) _SmsQueue.Enqueue(notifier);
                foreach (EmailNotifier notifier in GetEmailContactsList(data)) _EMailQueue.Enqueue(notifier);
            });
        }

        private List<SmsNotifier> GetSmsContactsList(NotifyData data)
        {
            List<SmsNotifier> smsNotifiers = new List<SmsNotifier>();
            foreach(string contact in data.SmsContacts)
            {
                smsNotifiers.Add(new SmsNotifier(_context, _configData.smsComPort)
                {
                    contact = contact,
                    method = "SMS",
                    message = data.message,
                    userId = data.userId
                });
            }
            return smsNotifiers;
        }

        private List<EmailNotifier> GetEmailContactsList(NotifyData data)
        {
            List<EmailNotifier> EmailNotifiers = new List<EmailNotifier>();
            foreach (string contact in data.MailContacts)
            {
                EmailNotifiers.Add(new EmailNotifier(
                    _context, _configData.mailData.credentials, _configData.mailData.service)
                {
                    contact = contact,
                    method = "EMAIL",
                    message = data.message,
                    userId = data.userId
                });
            }
            return EmailNotifiers;
        }

    }
}
