using System.Diagnostics;
using System.Drawing;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.ZKWeb;


namespace Decoder;

public class VideoHandler : IVideoHandler
{
    public List<string> GetFrames(string videoPath)
    {
        var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);
        var currentDirectory = Environment.CurrentDirectory;
        var argument = $"-i \"{videoPath}\" \"{tempDir}\\%09d.bmp\"";
        var p = Process.Start(Path.Combine(currentDirectory, "ffmpeg.exe"), argument);
        p.WaitForExit();
        return Directory.EnumerateFiles(tempDir).ToList();
    }

    public string ReadData(string filePath)
    {
        using var fs = File.Open(filePath, FileMode.Open);
        var bitMap = (System.DrawingCore.Bitmap)System.DrawingCore.Image.FromStream(fs);
        var source = new BitmapLuminanceSource(bitMap);
        var binaryBitmap = new BinaryBitmap(new HybridBinarizer(source));
        var reader = new QRCodeReader();
        return reader.decode(binaryBitmap).Text;
    }
}