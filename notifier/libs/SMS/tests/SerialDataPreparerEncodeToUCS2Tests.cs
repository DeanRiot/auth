using NUnit.Framework;

namespace sms_tests
{
    public class SerialDataPreparerEncodeToUCS2Tests
    {
        /// <summary>
        /// UCS-2 charset table http://www.columbia.edu/kermit/ucs2.html
        /// In same cases is UTF-8 encoding
        /// </summary>
        [TestCase("70000000000", "Hello world", "48656c6c6f20776f726c64")]
        [TestCase("70000000000", "Текстовое сообщение", "d0a2d0b5d0bad181d182d0bed0b2d0bed0b520d181d0bed0bed0b1d189d0b5d0bdd0b8d0b5")]
        [TestCase("70000000000", "1234567890", "31323334353637383930")]
        [TestCase("70000000000", "Sms от абонента: 70000000000", "536d7320d0bed18220d0b0d0b1d0bed0bdd0b5d0bdd182d0b03a203730303030303030303030")]
        public void SerialDataPreparer_EncodeToUtf8_Return_Right_MessageBytes(string phone, string msg, string want)
        {
            SerialDataPreparer _serialDataPreparer = new SerialDataPreparer();
            string data = _serialDataPreparer.PrepareData(phone, msg);

            if (data.Contains(want)) Assert.Pass();
            else Assert.Fail();

        }

        [TestCase("70000000000", "Hello world", "48656c6c6f20776f726c64")]
        [TestCase("70000000000", "Текстовое сообщение", "d0a2d0b5d0bad181d182d0bed0b2d0bed0b520d181d0bed0bed0b1d189d0b5d0bdd0b8d0b5")]
        [TestCase("70000000000", "1234567890", "31323334353637383930")]
        [TestCase("70000000000", "Sms от абонента: 70000000000", "536d7320d0bed18220d0b0d0b1d0bed0bdd0b5d0bdd182d0b03a203730303030303030303030")]
        [TestCase("70000000000", "", "")]
        public void SerialDataPreparer_PrepareData_Return_Right_Placed_Message(string phone, string msg, string want)
        {
            SerialDataPreparer _serialDataPreparer = new SerialDataPreparer();
            string data = _serialDataPreparer.PrepareData(phone, msg);
            string message = data.Substring(36);
            Assert.AreEqual(want, message);
        }
    }
}