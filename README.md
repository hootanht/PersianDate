# Persian Date Library

![Persian Date Library](https://lh3.googleusercontent.com/p_InfUloerXCEMJLLGA4n8HAQT7yR1kTn53cpYwFlFHkqa9TlaXE9K6BVef6i19JJzo=s180-rw)

Persian Data Library is a library that can be convert **Gregorian** (Milady) year to **Solar Hijri** (Shamsi) year in simplest way!

-------------------------

| Target | Branch | Version |
| ------ | ------ | ------ |
| Github | master | v1.0.0 | 


## Persian Date Public Version
| Target | Branch | Version | Download link | Total downloads |
| ------ | ------ | ------ | ------ | ------ |
| Nuget | master | v1.0.0 | [![NuGet](https://img.shields.io/nuget/v/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi) | [![NuGet downloads](https://img.shields.io/nuget/dt/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi) |
| Release | master | v1.0.0 | [![Release](http://s9.picofile.com/file/8353468992/releases.PNG)](https://github.com/hootanht/PrsianDate) | |

## Cross Platform

| Platform | Supported Version |
| ------ | ------ |
| .NET Standard | 2.1 |

## Code Example

    ```c#
    PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
    
    Console.WriteLine(await persianDateShamsi.GetShamsiYearAsync(DateTime.Now));
    //Result : 1398
    
    Console.WriteLine(await persianDateShamsi.GetShamsiMonthNameAsync(DateTime.Now));
    //Result : بهمن
    
    Console.WriteLine(await persianDateShamsi.GetShamsiDayStringAsync(DateTime.Now));
    //Result : 03
    
    Console.WriteLine(await persianDateShamsi.GetShamsiDayNameAsync(DateTime.Now));
    //Result : پنجشنبه
    
    Console.WriteLine(await persianDateShamsi.GetShamsiDayShortNameAsync(DateTime.Now));
    //Result : پ
    ```
Extension Method For DateTime

    ```c#
    Console.WriteLine(await DateTime.Now.ToShamsiDate());
    //Result : 1398/11/03
    
    Console.WriteLine(await DateTime.Now.ToShortShamsiDate());
    //Result : 98/11/03
    
    Console.WriteLine(await DateTime.Now.ToLongShamsiDate());
    //Result : پنجشنبه 3 بهمن 1398
    ```
    


## Developer

| Name | Github | Email | Telegram |
| ------ | ------ | ------ | ------ |
| Hootan Hemmati | [@hootanht](https://github.com/hootanht) | [hootanhemmati@outlook.com](mailto:hootanhemmati@outlook.com) | https://t.me/hootanht |
