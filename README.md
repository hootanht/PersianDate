# Persian Date Library

![Persian Date Library](https://lh3.googleusercontent.com/p_InfUloerXCEMJLLGA4n8HAQT7yR1kTn53cpYwFlFHkqa9TlaXE9K6BVef6i19JJzo=s180-rw)

Convert Gregorian (Miladi) dates to Solar Hijri (Shamsi) dates with ease!

[![NuGet](https://img.shields.io/nuget/v/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi)
[![NuGet downloads](https://img.shields.io/nuget/dt/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi)
[![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/CI.yml/badge.svg)](https://github.com/hootanht/PersianDate/actions)
[![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/CD.yml/badge.svg)](https://github.com/hootanht/PersianDate/actions)

## Features

- Convert Gregorian dates to Shamsi (Persian) dates
- Support for both `DateTime` and `DateTimeOffset`
- Get Shamsi year, month, and day components
- Get Shamsi month and day names
- Extension methods for easy conversion

## Installation

Install the package via NuGet:

```sh
dotnet add package PersianDateShamsi
```

## Usage

### Basic Conversion

```csharp
using PersianDate;

PersianDateShamsi persianDate = new PersianDateShamsi();
DateTime now = DateTime.Now;

int shamsiYear = persianDate.GetShamsiYear(now);
string shamsiMonthName = persianDate.GetShamsiMonthName(now);
string shamsiDayString = persianDate.GetShamsiDayString(now);
string shamsiDayName = persianDate.GetShamsiDayName(now);
string shamsiDayShortName = persianDate.GetShamsiDayShortName(now);

Console.WriteLine($"Year: {shamsiYear}");
// Output: Year: 1402

Console.WriteLine($"Month: {shamsiMonthName}");
// Output: Month: فروردین

Console.WriteLine($"Day: {shamsiDayString}");
// Output: Day: 01

Console.WriteLine($"Day Name: {shamsiDayName}");
// Output: Day Name: سه‌شنبه

Console.WriteLine($"Short Day Name: {shamsiDayShortName}");
// Output: Short Day Name: سه‌
```

### Extension Methods

```csharp
using PersianDate;

DateTime? dateTime = new DateTime(2023, 10, 5);
DateTimeOffset? dateTimeOffset = new DateTimeOffset(2023, 10, 5, 0, 0, 0, TimeSpan.Zero);

Console.WriteLine(dateTime.ToShamsiDate());        
// Output: 1402/07/13

Console.WriteLine(dateTimeOffset.ToShamsiDate());  
// Output: 1402/07/13

Console.WriteLine(dateTime.ToShortShamsiDate());        
// Output: 02/07/13

Console.WriteLine(dateTimeOffset.ToShortShamsiDate());  
// Output: 02/07/13

Console.WriteLine(dateTime.ToLongShamsiDate());        
// Output: پنجشنبه 13 مهر 1402

Console.WriteLine(dateTimeOffset.ToLongShamsiDate());  
// Output: پنجشنبه 13 مهر 1402
```

### Converting to Gregorian

```csharp
using PersianDate;

ToGregorian toGregorian = new ToGregorian();

int gregorianYear = toGregorian.GetGregorianYear(1402, 1, 1);
DateTime gregorianDate = toGregorian.ToGregorianDate(1402, 1, 1);
int gregorianMonth = toGregorian.GetGregorianMonth(1402, 1, 1);
int gregorianDay = toGregorian.GetGregorianDay(1402, 1, 1);

Console.WriteLine($"Gregorian Year: {gregorianYear}");
// Output: Gregorian Year: 2023

Console.WriteLine($"Gregorian Date: {gregorianDate}");
// Output: Gregorian Date: 2023-03-21

Console.WriteLine($"Gregorian Month: {gregorianMonth}");
// Output: Gregorian Month: 3

Console.WriteLine($"Gregorian Day: {gregorianDay}");
// Output: Gregorian Day: 21
```

## Supported Platforms

- .NET 5.0
- .NET 6.0
- .NET 7.0
- .NET 8.0
- .NET 9.0

## Getting Started

1. Install [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
2. Clone the repository:
   ```sh
   git clone https://github.com/hootanht/PersianDate.git
   ```
3. Navigate to the project directory:
   ```sh
   cd PersianDate
   ```
4. Restore dependencies:
   ```sh
   dotnet restore
   ```
5. Build the project:
   ```sh
   dotnet build
   ```
6. Run tests:
   ```sh
   dotnet test
   ```

## Version History

| Version | Changes                                      |
|---------|----------------------------------------------|
| 1.9.1   | Add support for older .NET versions (netstandard2.0, netstandard2.1, netcoreapp3.1, net5.0) and .NET 9.0 |
| 1.0.9   | Upgraded to .NET 9.0                         |
| 1.0.8   | Added support for `DateTimeOffset` in `ToGregorian` class and updated `PersianDateShamsi.cs` and `ToShamsi.cs` accordingly |
| 1.0.6   | Added support for .NET 8.0                   |
| 1.0.4   | Added support for .NET 5.0 and 6.0           |
| 1.0.3   | Changed from .NET Standard 2.0 to .NET 7.0   |
| 1.0.2   | Improved flexibility                         |
| 1.0.1   | Changed from .NET Standard 2.1 to 2.0 for broader platform support |

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

If you encounter any issues or have questions, please [open an issue](https://github.com/hootanht/PersianDate/issues) on GitHub.

---

Made with ❤️ by [Hootan Hemmati](https://github.com/hootanht)