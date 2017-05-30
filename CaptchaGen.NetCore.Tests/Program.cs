using System;
using System.IO;

namespace CaptchaGen.NetCore.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = File.OpenWrite("d:/1.jpg"))
            using (Stream picStream = ImageFactory.BuildImage("AB123", 50, 100, 20,10, ImageFormatType.Jpeg))
            {
                picStream.CopyTo(fs);
            }
            Console.ReadKey();
        }
    }
}