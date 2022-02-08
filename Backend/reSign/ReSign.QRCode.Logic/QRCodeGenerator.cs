using Net.Codecrete.QrCodeGenerator;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Text;

namespace ReSign.QRCode.Logic
{
    public abstract class QRCodeGenerator
    {
        public static double LogoWidth => 0.15;       //Width of logo in percent

        /// <summary>
        /// Asynchronously generates the contents of a png file with the corresponding QrCode for the given text
        /// </summary>
        /// <param name="text">Contents of the QrCode</param>
        /// <param name="border">Space between the QrCode and the edge of the image</param>
        /// <param name="scale">Size of each module in pixels</param>
        /// /// <param name="logoFilePath">Filepath of logo to show in the middle of the QrCode</param>
        /// <returns>The contents of a png file as a byte[]</returns>
        public static Task<byte[]> GeneratePngBytesAsync(string text, int border = 4, int scale = 10, string? logoFilePath = null)
        {
            return Task.Run(() =>
            {
                var qr = QrCode.EncodeText(text, QrCode.Ecc.Medium);
                using var qrImg = qr.ToBitmap(scale, border);

                //Check if logo is specified
                if(logoFilePath != null)
                {
                    //Check if given filepath exists
                    if (!File.Exists(logoFilePath))
                        throw new FileNotFoundException("Logo file doesn't exist!", logoFilePath);

                    //load logo
                    using var logo = Image.Load(logoFilePath);

                    // resize logo
                    var w = (int)Math.Round(qrImg.Width * LogoWidth);
                    logo.Mutate(logo => logo.Resize(w, 0));

                    // draw logo in center
                    var topLeft = new Point((qrImg.Width - logo.Width) / 2, (qrImg.Height - logo.Height) / 2);
                    qrImg.Mutate(img => img.DrawImage(logo, topLeft, 1));

                    //Return modified image
                    return ConvertImageToPngBytes(qrImg);
                }
                
                //Return qrCode without logo
                return qr.ToPng(scale, border);
            });
        }

        /// <summary>
        /// Uses the GeneratePngBytesAsync() method to generate the contents, and saves it to the given filepath.
        /// </summary>
        /// <param name="filepath">Path for the output image</param>
        /// <param name="text">Contents of the QrCode</param>
        /// <param name="border">Space between the QrCode and the edge of the image</param>
        /// <param name="scale">Size of each module in pixels</param>
        /// <returns>The task executing this method</returns>
        /// <exception cref="ArgumentException">If filepath doesn't end with '.png'</exception>
        public static Task GeneratePngFileAsync(string filepath, string text, int border = 4, int scale = 10, string? logoFilePath = null)
        {
            if (!filepath.EndsWith(".png"))
                throw new ArgumentException("Filepath for png file must end with \".png\"!");

            return Task.Run(async () =>
            {
                var fileContent = await GeneratePngBytesAsync(text, border, scale, logoFilePath);
                File.WriteAllBytes(filepath, fileContent);
            });
        }

        private static byte[] ConvertImageToPngBytes(Image img)
        {
            using var ms = new MemoryStream();
            img.SaveAsPng(ms);
            return ms.ToArray();
        }
    }
}