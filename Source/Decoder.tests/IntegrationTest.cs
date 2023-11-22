using System.Diagnostics;
using System.Reflection;

namespace Decoder.tests;

public class IntegrationTest
{
    [Fact]
    public void GetFrames_ReturnsListOfFrames_Success()
    {
        IVideoHandler handler = new VideoHandler();
        var files = handler.GetFrames(@Path.GetFullPath("./Resources/joined_video.mp4"));
        var data = handler.ReadData(files.First());
        Assert.True(files.Count == 26 && data.Contains("6tLI^AKYQ)+D#F5FCfN86tLI^AKYQ)"));
        foreach (var result in files)
        {
            File.Delete(result);
        }
    }
}