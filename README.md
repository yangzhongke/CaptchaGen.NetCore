# CaptchaGen.NetCore
Captcha generator for .net core 
migration from [CaptchaGen](https://github.com/vishnuprasadv/CaptchaGen) by yangzhongke from [rupeng.com](http://www.rupeng.com)  

Nuget Install:  
>Install-Package CaptchaGen.NetCore 

Example Code:  
```C#
    using (FileStream fs = File.OpenWrite("d:/1.jpg"))
    using (Stream picStream = ImageFactory.BuildImage("AB123", 50, 100, 20,10, ImageFormatType.Jpeg))
    {
	picStream.CopyTo(fs);
    }
````
Also be careful when using the library cross-platform, to include the runtime.osx.10.10-x64.CoreCompat.System.Drawing and / or runtime.linux-x64.CoreCompat.System.Drawing packages.  

Nuget: CoreCompat.System.Drawing, runtime.osx.10.10-x64.CoreCompat.System.Drawing, and runtime.linux-x64.CoreCompat.System.Drawing  

see [this page](https://blogs.msdn.microsoft.com/dotnet/2017/01/19/net-core-image-processing/)
