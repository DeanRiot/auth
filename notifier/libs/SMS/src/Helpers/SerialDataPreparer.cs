using System;
using System.Linq;
using System.Text;

namespace Sms.Helpers
{
    internal class SerialDataPreparer
    {
        public string PrepareData(string phone, string message)
        {
            StringBuilder pdu = new StringBuilder();
            pdu.Append("ATZ\r");
            pdu.Append("AT+CMGF=0\r");
            pdu.Append("0001000B91");//cfg bytes
            pdu.Append(PreparePhone(phone));
            pdu.Append(PrepareMessage(message));
            return pdu.ToString();
        }
        private string PreparePhone(string phone)
        {
            var d = phone.ToList();
            if (d.Contains('+')) d.Remove('+');
            if (d.Count() % 2 != 0) d.Add('F');
            for (int i = 0; i < d.Count(); i += 2)
            {
                var temp = d[i];
                d[i] = d[i + 1];
                d[i + 1] = temp;
            }
            var result = new string(d.ToArray());
            return result;
        }

        private string PrepareMessage(string message)
        {
            string hex = BitConverter.ToString(
                                     EncodeToUtf8(message))
                                     .Replace("-", string.Empty);
            return hex;
        }
        private byte[] EncodeToUtf8(string text)
        {
            string utf8_String = text;
            byte[] bytes = Encoding.Default.GetBytes(text);
            utf8_String = Encoding.UTF8.GetString(bytes);
            return Encoding.UTF8.GetBytes(utf8_String);
        }
    }
}
