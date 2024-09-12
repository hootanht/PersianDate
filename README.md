# Persian Date Library

![Persian Date Library](https://lh3.googleusercontent.com/p_InfUloerXCEMJLLGA4n8HAQT7yR1kTn53cpYwFlFHkqa9TlaXE9K6BVef6i19JJzo=s180-rw)

Persian Data Library is a library that can be convert **Gregorian** (Milady) year to **Solar Hijri** (Shamsi) year in simplest way!

-------------------------

| Target | Branch | Version |
| ------ | ------ | ------ |
| Github | master | v1.0.5 | 


## Persian Date Public Version
| Target | Branch | Version | Download link | Total downloads | CI Build Status | CD Build Status |
| ------ | ------ | ------ | ------ | ------ | ------ | ------ |
| Nuget | master | v1.0.5 | [![NuGet](https://img.shields.io/nuget/v/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi) | [![NuGet downloads](https://img.shields.io/nuget/dt/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi) | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/ci.yml/badge.svg)](https://github.com/hootanht/PersianDate/actions) | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/cd.yml/badge.svg)](https://github.com/hootanht/PersianDate/actions) |
| Release | master | v1.0.5 | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/ci.yml/badge.svg)](https://github.com/hootanht/PersianDate/actions) | | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/ci.yml/badge.svg)](https://github.com/hootanht/PersianDate/actions) | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/cd.yml/badge.svg)](https://github.com/hootanht/PersianDate/actions) |

## Cross Platform

| Platform | Supported Version |
| ------ | ------ |
| .NET | 8.0 |

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
Version 1.0.5

-Add support for .Net 8.0

Version 1.0.4

-Add support for .Net 5.0 and 6.0

Version 1.0.3

-Change .Net Standard 2.0 To .NET 7.0

Version 1.0.2

-Improve Flexibility

Version 1.0.1

-Change .Net Standard 2.1 To 2.0 To Support More Platforms

## CI Pipeline

The CI pipeline is defined in `.github/workflows/ci.yml` and uses `macos-latest` as the VM image. It restores NuGet packages, builds the solution, and runs tests. The pipeline installs .NET version 8.0.x to ensure compatibility with all targeted frameworks.

## CD Pipeline

The CD pipeline is defined in `.github/workflows/cd.yml` and uses `macos-latest` as the VM image. It restores NuGet packages, builds the solution, runs tests, and publishes the NuGet package. The pipeline installs .NET version 8.0.x to ensure compatibility with all targeted frameworks. Additionally, it includes a step to delete existing tags if they already exist before creating a new release to avoid the 'Validation Failed: already_exists' error.

## Developer [![Twitter Follow](https://img.shields.io/twitter/follow/hootanht?style=social)](https://twitter.com/hootanht)

| Name | Github | Email | Telegram |
| ------ | ------ | ------ | ------ |
| Hootan Hemmati | [@hootanht](https://github.com/hootanht) | [hootanhemmati@outlook.com](mailto:hootanhemmati@outlook.com) | https://t.me/hootanht |
