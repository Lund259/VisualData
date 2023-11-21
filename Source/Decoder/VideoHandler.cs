using System.Diagnostics;
using System.Drawing;
using FFMpegCore;

namespace Decoder;

public class VideoHandler: IVideoHandler
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
}