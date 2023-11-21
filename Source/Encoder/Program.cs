// See https://aka.ms/new-console-template for more information


using SimpleBase;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ZXing.Common;

const int squareSize = 10;

var bytes = File.ReadAllBytes("test.txt");
var bytesString = Base85.Ascii85.Encode(bytes);



var imageFileName = "qrcode.png";

var width = 250;  
var height = 250;
var margin = 0; 
var barcodeWriter = new ZXing.ImageSharp.BarcodeWriter<Rgba32> { 
    Format = ZXing.BarcodeFormat.CODE_128, 
    Options = new EncodingOptions { 
        Height = height, Width = width, Margin = margin 
    }
}; 


using (var image = barcodeWriter.Write(bytesString))
{
    image.SaveAsGif("test.gif");
}