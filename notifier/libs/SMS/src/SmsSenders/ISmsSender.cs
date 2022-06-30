using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.SmsSenders
{
    public interface ISmsSender
    {
        public void Send(string to, string message);
        public Task SendAsync(string to, string message); 
    }
}
