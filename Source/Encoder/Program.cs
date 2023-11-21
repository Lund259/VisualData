// See https://aka.ms/new-console-template for more information


using FFMpegCore;
using SimpleBase;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ZXing.Common;

var filenames = new List<string>();

await using var fileStream = File.OpenRead(@"C:\Users\Jonat\Desktop\Test.txt");
{
    var buffer = new byte[2000];

    while (await fileStream.ReadAsync(buffer) > 0)
    {
        var bytesString = Base85.Ascii85.Encode(buffer);

        var barcodeWriter = new ZXing.ImageSharp.BarcodeWriter<Rgba32> { 
            Format = ZXing.BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                NoPadding = true,
                Margin = 0,
                Width = 166,
                Height = 166
            }
        };

        using var image = barcodeWriter.Write(bytesString);
        var fileName = $"{Guid.NewGuid()}.bmp";
        await image.SaveAsBmpAsync(fileName);
        
        filenames.Add(fileName);
    }
}

FFMpeg.JoinImageSequence("joined_video.mp4", 30D, filenames.ToArray());
filenames.ForEach(x => new FileInfo(x).Delete());