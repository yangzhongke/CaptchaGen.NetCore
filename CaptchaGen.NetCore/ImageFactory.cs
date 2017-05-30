using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace CaptchaGen.NetCore
{
    /// <summary>
    /// Generates a captcha image based on the captcha code string given.
    /// yangzhongke(http://www.rupeng.com) migrated from https://github.com/vishnuprasadv/CaptchaGen/blob/master/CaptchaGen/ImageFactory.cs
    /// </summary>
    public static class ImageFactory
    {
        const int HEIGHT = 96;
        const int WIDTH = 150;
        const string FONTFAMILY = "Arial";
        const int FONTSIZE = 25;

        /// <summary>
        /// Background color to be used.
        /// Default value = Color.Wheat
        /// </summary>
        public static Color BackgroundColor { get; set; } = Color.Wheat;
        

        /// <summary>
        /// Actual image generator. Internally used.
        /// </summary>
        /// <param name="captchaCode">Captcha code for which the image has to be generated</param>
        /// <param name="imageHeight">Height of the image to be generated</param>
        /// <param name="imageWidth">Width of the image to be generated</param>
        /// <param name="fontSize">Font size to be used</param>
        /// <param name="distortion">Distortion required</param>
        /// <returns>Generated jpeg image as a MemoryStream object</returns>
        public static MemoryStream BuildImage(string captchaCode, int imageHeight, int imageWidth, int fontSize, int distortion=18,
            ImageFormatType imgType= ImageFormatType.Png)
        {
            int newX, newY;
            MemoryStream memoryStream = new MemoryStream();
            using (Bitmap captchaImage = new Bitmap(imageWidth, imageHeight, System.Drawing.Imaging.PixelFormat.Format64bppArgb))
            using (Bitmap cache = new Bitmap(imageWidth, imageHeight, System.Drawing.Imaging.PixelFormat.Format64bppArgb))
            using (Graphics graphicsTextHolder = Graphics.FromImage(captchaImage))
            {
                graphicsTextHolder.Clear(BackgroundColor);
                graphicsTextHolder.DrawString(captchaCode, new Font(FONTFAMILY, fontSize, FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(8.4F, 20.4F));

                //Distort the image with a wave function
                for (int y = 0; y < imageHeight; y++)
                {
                    for (int x = 0; x < imageWidth; x++)
                    {
                        newX = (int)(x + (distortion * Math.Sin(Math.PI * y / 64.0)));
                        newY = (int)(y + (distortion * Math.Cos(Math.PI * x / 64.0)));
                        if (newX < 0 || newX >= imageWidth) newX = 0;
                        if (newY < 0 || newY >= imageHeight) newY = 0;
                        cache.SetPixel(x, y, captchaImage.GetPixel(newX, newY));
                    }
                }
                System.Drawing.Imaging.ImageFormat imgFormat;
                switch (imgType)
                {
                    case ImageFormatType.Bmp:
                        imgFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    case ImageFormatType.Gif:
                        imgFormat = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    case ImageFormatType.Jpeg:
                        imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ImageFormatType.Png:
                        imgFormat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    default:
                        throw new ArgumentException("unkown image type");
                }
                cache.Save(memoryStream, imgFormat);
                memoryStream.Position = 0;
                return memoryStream;
            }            
        }
    }
}
