using System;
using System.IO;

namespace CaptchaGen.NetCore.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageFactory.Distortion = 10;
            using (FileStream fs = File.OpenWrite("d:/1.jpg"))
            using (Stream picStream = ImageFactory.GenerateImage("AB123", 50, 100, 20))
            {
                picStream.CopyTo(fs);
            }
            Console.ReadKey();
        }
    }
}