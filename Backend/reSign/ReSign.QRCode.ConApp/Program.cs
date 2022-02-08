using ReSign.QRCode.Logic;

Console.WriteLine("ReSign QrCode Generator |");
Console.WriteLine("------------------------+");


var task = QRCodeGenerator.GeneratePngFileAsync("qrcode.png", "https://resign.byiconic.at/dev", logoFilePath: "reSignLogo.png");
Console.WriteLine("QrCode generation started...");
task.Wait();

Console.WriteLine("QrCode generation finished!");