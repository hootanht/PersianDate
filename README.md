# Persian Date Library

![Persian Date Library](https://lh3.googleusercontent.com/p_InfUloerXCEMJLLGA4n8HAQT7yR1kTn53cpYwFlFHkqa9TlaXE9K6BVef6i19JJzo=s180-rw)

Persian Data Library is a library that can be convert **Gregorian** (Milady) year to **Solar Hijri** (Shamsi) year in simplest way!

-------------------------

| Target | Branch | Version |
| ------ | ------ | ------ |
| Github | master | v1.0.2 | 


## Persian Date Public Version
| Target | Branch | Version | Download link | Total downloads |
| ------ | ------ | ------ | ------ | ------ |
| Nuget | master | v1.0.2 | [![NuGet](https://img.shields.io/nuget/v/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi) | [![NuGet downloads](https://img.shields.io/nuget/dt/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi) |
| Release | master | v1.0.2 | [![Build Status](https://dev.azure.com/hootanht/PersianDate/_apis/build/status/PersianDate?branchName=master)](https://dev.azure.com/hootanht/PersianDate/_apis/build/status/PersianDate?branchName=master) | |

## Cross Platform

| Platform | Supported Version |
| ------ | ------ |
| .NET Framework | 4.6.1 Or Higher|
| .NET Standard | 2.0 Or Higher|
| .NET Core | 2.0 Or Higher|
| Mono | 5.4 Or Higher|
| Xamarin.iOS | 10.14 Or Higher|
| Xamarin.Mac | 3.8 Or Higher|
| Xamarin.Android | 8.0 Or Higher|
| Universal Windows Platform (UWP) | 10.0.16299 Or Higher|
| Unity | 2018.1 Or Higher|

## Code Example

```c#
PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
    
    Console.WriteLine(persianDateShamsi.GetShamsiYear(DateTime.Now));
    //Result : 1398
    
    Console.WriteLine(persianDateShamsi.GetShamsiMonthName(DateTime.Now));
    //Result : بهمن
    
    Console.WriteLine(persianDateShamsi.GetShamsiDayString(DateTime.Now));
    //Result : 03
    
    Console.WriteLine(persianDateShamsi.GetShamsiDayName(DateTime.Now));
    //Result : پنجشنبه
    
    Console.WriteLine(persianDateShamsi.GetShamsiDayShortName(DateTime.Now));
    //Result : پ
```

Extension Method For DateTime

```c#

    Console.WriteLine(DateTime.Now.ToShamsiDate());
    //Result : 1398/11/03
    
    Console.WriteLine(DateTime.Now.ToShortShamsiDate());
    //Result : 98/11/03
    
    Console.WriteLine(DateTime.Now.ToLongShamsiDate());
    //Result : پنجشنبه 3 بهمن 1398
```

## Version changes
v1.0.2

-Improve Flexibility

v1.0.1

-Change .Net Standard 2.1 To 2.0 To Support More Platforms
## Developer [![Twitter Follow](https://img.shields.io/twitter/follow/hootanht?style=social)](https://twitter.com/hootanht)

| Name | Github | Email | Telegram |
| ------ | ------ | ------ | ------ |
| Hootan Hemmati | [@hootanht](https://github.com/hootanht) | [hootanhemmati@outlook.com](mailto:hootanhemmati@outlook.com) | https://t.me/hootanht |
