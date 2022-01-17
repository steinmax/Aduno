using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReSign.QRCode.Logic;

namespace ReSign.QRCode.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestQRCodeGen()
        {
            QRCodeGen qrCodeGen = new QRCodeGen();
            qrCodeGen.QrCodeWithImage();
        }
    }
}