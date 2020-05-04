using System;
using System.IO;

namespace CaptchaGen.NetCore.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = ImageFactory.CreateCode(5);
            using (FileStream fs = File.OpenWrite("d:/1.jpg"))
            using (Stream picStream = ImageFactory.BuildImage(code, 50, 100, 20,10))
            {
                picStream.CopyTo(fs);
            }
            //Console.ReadKey();
        }
    }
}