using NUnit.Framework;
using Sms.Helpers;

namespace sms_tests
{
    internal class SerialDataPreparerPhoneEncodingTests
    {
        [TestCase("70000000000", "0700000000f0")]
        [TestCase("79030901923", "9730901029f3")]
        [TestCase("78019911233", "8710991132f3")]
        public void SerialDataPreparer_PreparePhone_Return_Phone_Number(string number, string want)
        {
            SerialDataPreparer _serialDataPreparer = new SerialDataPreparer();
            string data = _serialDataPreparer.PrepareData(number, "");
            if (data.Contains(want)) Assert.Pass();
            else Assert.Fail($"{want} not found in {data}");
        }

        [TestCase("70000000000", "0700000000f0")]
        [TestCase("79030901923", "9730901029f3")]
        [TestCase("78019911233", "8710991132f3")]
        public void SerialDataPreparer_PreparePhone_Return_RightPlaced_Phone_Number(string number, string want)
        {
            SerialDataPreparer _serialDataPreparer = new SerialDataPreparer();
            string data = _serialDataPreparer.PrepareData(number, "");
            string phone = data.Substring(24,12);
            Assert.AreEqual(want, phone,$"{phone} not eq with {want}");
        }
    }
}
