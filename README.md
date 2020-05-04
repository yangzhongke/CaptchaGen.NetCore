# CaptchaGen.NetCore
Captcha generator for .net core 
migration from [CaptchaGen](https://github.com/vishnuprasadv/CaptchaGen) by yangzhongke from [rupeng.com](http://www.rupeng.com)  

Nuget Install:  
>Install-Package CaptchaGen.NetCore 

Example Code:  
```C#
    string code = ImageFactory.CreateCode(5);
    using (FileStream fs = File.OpenWrite("d:/1.jpg"))
    using (Stream picStream = ImageFactory.BuildImage(code, 50, 100, 20,10, ImageFormatType.Jpeg))
    {
	picStream.CopyTo(fs);
    }
````