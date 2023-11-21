namespace Decoder;

public interface IVideoHandler
{
    public byte[] GetFrames(string videoPath);
}