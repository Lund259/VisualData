using System.Diagnostics;
using System.Reflection;

namespace Decoder.tests;

public class IntegrationTest
{
    [Fact]
    public void GetFrames_ReturnsListOfFrames_Success()
    {
        IVideoHandler handler = new VideoHandler();
        var results = handler.GetFrames(@Path.GetFullPath("./Resources/joined_video.mp4"));
        Assert.True(results.Count == 26);
        foreach (var result in results)
        {
            File.Delete(result);
        }
    }
}