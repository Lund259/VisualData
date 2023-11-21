using OpenCvSharp;

namespace Decoder;

public class VideoHandler: IVideoHandler
{
    public InputArray GetFrames(string videoPath)
    {
        var capture = new VideoCapture(videoPath);
        var image = new Mat();
        Console.WriteLine("Begin extracting frames from video file..");
        List<Mat> mats = new();
        while (capture.IsOpened())
        {
            // Read next frame in video file
            capture.Read(image);
            if (image.Empty())
            {
                break;
            }
            mats.Add(image);
        }
        return InputArray.Create(mats);
    }
}