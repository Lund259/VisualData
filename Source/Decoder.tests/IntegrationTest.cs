using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Decoder.tests;

public class IntegrationTest
{
    [Fact]
    public void GetFrames_ReturnsListOfFrames_Success()
    {
        IVideoHandler handler = new VideoHandler();
        var files = handler.GetFrames(@Path.GetFullPath("./Resources/joined_video.mp4"));
        var data = handler.ReadData(files.First());
        var bytes = handler.GetFile(data);
        var ct = Encoding.UTF8.GetString(bytes);
        Assert.True(files.Count == 26 && data.Contains("6tLI^AKYQ)+D#F5FCfN86tLI^AKYQ)") && ct.Contains("test"));
        foreach (var result in files)
        {
            File.Delete(result);
        }
    }

    [Fact]
    public void Test()
    {
        IVideoHandler handler = new VideoHandler();
        var files = handler.GetFrames(@"C:\Users\e-ole\Downloads\Test2.txt.mp4");
        StringBuilder sb = new();
        foreach (var file in files)
        {
            sb.Append(handler.ReadData(file));
        }
        var bytes = handler.GetFile(sb.ToString());
        using var writer = new BinaryWriter(File.OpenWrite(@"C:\temp\Test2.txt"));
        writer.Write(bytes);
    }
}