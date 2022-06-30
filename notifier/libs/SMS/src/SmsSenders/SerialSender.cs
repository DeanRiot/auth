using Sms.Helpers;
using System.IO.Ports;
using System.Threading.Tasks;

namespace Sms.SmsSenders
{
    public class SerialSender : ISmsSender
    {
        SerialPort _serial;
        SerialDataPreparer _dataPreparer = new SerialDataPreparer();
        public SerialSender(string port) =>
                 _serial = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);

        public void Send(string to, string message) =>
             _serial.Write(_dataPreparer.PrepareData(to, message));

        public async void SendAsync(string to, string message) =>
                              await Task.Run(() => Send(to, message));

    }
}
