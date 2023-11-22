// See https://aka.ms/new-console-template for more information


using FFMpegCore;
using SimpleBase;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ZXing.Common;

var filenames = new List<string>();

var barcodeWriter = new ZXing.ImageSharp.BarcodeWriter<Rgba32> { 
    Format = ZXing.BarcodeFormat.QR_CODE,
    Options = new EncodingOptions
    {
        NoPadding = true,
        Margin = 0,
        Width = 178,
        Height = 178
    }
};

var inputFile = new FileInfo(@"C:\Users\Jonat\Desktop\Test2.txt");
await using var fileStream = inputFile.OpenRead();
{
    var buffer = new byte[2953];    //Max bytesize per QRCode in this format

    while (await fileStream.ReadAsync(buffer) > 0)
    {
        var charString = buffer.Aggregate("", (current, b) => current + (char) b);
        buffer = new byte[2953];

        using var image = barcodeWriter.Write(charString);
        var fileName = $"{Guid.NewGuid()}.bmp";
        await image.SaveAsBmpAsync(fileName);
        
        filenames.Add(fileName);
    }
}

FFMpeg.JoinImageSequence($"{inputFile.Name}.mp4", 30D, filenames.ToArray());
filenames.ForEach(x => new FileInfo(x).Delete());