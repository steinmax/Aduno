using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ReSign.QRCode.Logic.UnitTest
{
    [TestClass]
    public class QRCodeGeneratorTests
    {
        [TestMethod]
        public void CreateQRCode_ResignByiconicAt_ExpectNonNullByteArray()
        {
            var qrCode = QRCodeGenerator.GeneratePngBytesAsync("https://resign.byiconic.at")
                .Result;
            Assert.IsNotNull(qrCode);
        }

        [TestMethod]
        public void CreateQRCodePng_ResignByiconicAt_ExpectOutputFile()
        {
            const string outputFile = "test2_qr_output.png";
            //Delete File if already exists
            if(File.Exists(outputFile))
                File.Delete(outputFile);

            //Generate new file/qrcode
            QRCodeGenerator.GeneratePngFileAsync(outputFile, "https://resign.byiconic.at")
                .Wait();

            //Check if new file is created
            var exists = File.Exists(outputFile);
            Assert.IsTrue(exists);

            var sizeInBytes = File.ReadAllBytes(outputFile).Length;
            var sizeBiggerThan0 = sizeInBytes > 0;
            Assert.IsTrue(sizeBiggerThan0);
        }
    }
}