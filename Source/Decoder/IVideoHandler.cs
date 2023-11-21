namespace Decoder;

public interface IVideoHandler
{
    public List<string> GetFrames(string videoPath);
}