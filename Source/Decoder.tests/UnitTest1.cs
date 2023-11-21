using OpenCvSharp;

namespace Decoder.tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        IVideoHandler handler = new VideoHandler();
        VideoWriter vw = new("", FourCC.MJPG , 30, new Size(165, 165));
        //InputArray.Create()
        //vw.Write();
    }
}