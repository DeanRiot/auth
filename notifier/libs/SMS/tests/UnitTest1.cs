using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SMS;

namespace sms_tests
{
    public class Tests
    {

        [Test]
        public void SmsProvider_EncodeToUtf8_Return_Right_Bytes()
        {
            SmsProvider provider = new SmsProvider("COM 1");
            provider.Send("79013216565", "Hello World");
            
        }
    }
}