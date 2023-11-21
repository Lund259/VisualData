using OpenCvSharp;

namespace Decoder;

public interface IVideoHandler
{
    public InputArray GetFrames(string videoPath);
}