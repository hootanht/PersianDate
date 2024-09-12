# Persian Date Library

![Persian Date Library](https://lh3.googleusercontent.com/p_InfUloerXCEMJLLGA4n8HAQT7yR1kTn53cpYwFlFHkqa9TlaXE9K6BVef6i19JJzo=s180-rw)

Persian Data Library is a library that can be convert **Gregorian** (Milady) year to **Solar Hijri** (Shamsi) year in simplest way!

-------------------------

| Target | Branch | Version |
| ------ | ------ | ------ |
| Github | master | v1.0.8 | 


## Persian Date Public Version
| Target | Branch | Version | Download link | Total downloads | CI Build Status | CD Build Status |
| ------ | ------ | ------ | ------ | ------ | ------ | ------ |
| Nuget | master | v1.0.8 | [![NuGet](https://img.shields.io/nuget/v/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi) | [![NuGet downloads](https://img.shields.io/nuget/dt/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi) | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/CI.yml/badge.svg?branch=master)](https://github.com/hootanht/PersianDate/actions) | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/CD.yml/badge.svg?branch=master)](https://github.com/hootanht/PersianDate/actions) |
| Release | master | v1.0.8 | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/CI.yml/badge.svg?branch=master)](https://github.com/hootanht/PersianDate/actions) | | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/CI.yml/badge.svg?branch=master)](https://github.com/hootanht/PersianDate/actions) | [![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/CD.yml/badge.svg?branch=master)](https://github.com/hootanht/PersianDate/actions) |

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
Version 1.0.8

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

The CI pipeline is now integrated into the CD pipeline and is defined in `.github/workflows/CI.yml`. It uses `macos-latest` as the VM image. The pipeline handles manual triggers, pull requests, and releases. It restores NuGet packages, builds the solution, runs tests, and validates the NuGet package. The pipeline installs .NET version 8.0.x to ensure compatibility with all targeted frameworks.

## CD Pipeline

The CD pipeline is defined in `.github/workflows/CD.yml` and uses `macos-latest` as the VM image. It includes steps for creating, validating, testing, and deploying the NuGet package. The pipeline handles manual triggers, pull requests, and releases. It uses environment variables for the NuGet directory and the latest versions of GitHub Actions for checkout, setup-dotnet, and upload-artifact. The pipeline installs .NET version 8.0.x to ensure compatibility with all targeted frameworks. Additionally, it includes a step to delete existing tags if they already exist before creating a new release to avoid the 'Validation Failed: already_exists' error. The step now handles the case where the tag deletion fails and ensures the deletion step successfully removes the existing tag before proceeding to create a new release. The `fetch_changes` step now uses `pwsh` syntax: `$PREV_TAG = $(git describe --tags --abbrev=0 HEAD^)`. The pipeline now also triggers on `push` to `tags`.

## Requirements

- .NET 8.0 SDK

## Setup and Run

1. **Install .NET 8.0 SDK**: Download and install the .NET 8.0 SDK from the official [.NET website](https://dotnet.microsoft.com/download/dotnet/8.0).

2. **Restore Dependencies**: Open a terminal or command prompt in the project directory and run:
   ```sh
   dotnet restore
   ```

3. **Build the Project**: Build the project by running:
   ```sh
   dotnet build
   ```

4. **Run Tests**: Run the tests to ensure everything is working correctly:
   ```sh
   dotnet test
   ```

