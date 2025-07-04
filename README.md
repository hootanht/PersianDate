# Persian Date Library

![Persian Date Library](https://lh3.googleusercontent.com/p_InfUloerXCEMJLLGA4n8HAQT7yR1kTn53cpYwFlFHkqa9TlaXE9K6BVef6i19JJzo=s180-rw)

Convert Gregorian (Miladi) dates to Solar Hijri (Shamsi) dates with ease!

[![NuGet](https://img.shields.io/nuget/v/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi)
[![NuGet downloads](https://img.shields.io/nuget/dt/PersianDateShamsi.svg)](https://www.nuget.org/packages/PersianDateShamsi)
[![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/CI.yml/badge.svg)](https://github.com/hootanht/PersianDate/actions)
[![Build Status](https://github.com/hootanht/PersianDate/actions/workflows/CD.yml/badge.svg)](https://github.com/hootanht/PersianDate/actions)

## Features

### Core Features
- Convert Gregorian dates to Shamsi (Persian) dates
- Support for both `DateTime` and `DateTimeOffset`
- Get Shamsi year, month, and day components
- Get Shamsi month and day names
- Extension methods for easy conversion

### ✨ New in v1.9.3 - Advanced Features
- **🎨 Enhanced Formatting Options**: Multiple format styles, Persian/English digits, custom patterns
- **🔍 Date Parsing and Validation**: Parse Persian date strings with comprehensive validation
- **🌐 Localization and Culture Support**: Full Persian and English culture support with RTL text

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

### ✨ Enhanced Formatting Options (New in v1.9.3)

#### Multiple Format Styles
```csharp
using PersianDate;

DateTime date = new DateTime(2024, 3, 20);

// Predefined format styles
string short = ShamsiDateFormatter.Format(date, ShamsiFormatStyle.Short);
// Output: ۱۴۰۳/۱/۱

string medium = ShamsiDateFormatter.Format(date, ShamsiFormatStyle.Medium);
// Output: ۱ فرو ۱۴۰۳

string long = ShamsiDateFormatter.Format(date, ShamsiFormatStyle.Long);
// Output: ۱ فروردین ۱۴۰۳

string full = ShamsiDateFormatter.Format(date, ShamsiFormatStyle.Full);
// Output: چهارشنبه، ۱ فروردین ۱۴۰۳
```

#### Custom Format Patterns
```csharp
// Custom patterns with Persian digits (default)
string custom1 = ShamsiDateFormatter.Format(date, "yyyy/MM/dd");
// Output: ۱۴۰۳/۰۱/۰۱

string custom2 = ShamsiDateFormatter.Format(date, "dddd، dd MMMM yyyy");
// Output: چهارشنبه، ۰۱ فروردین ۱۴۰۳

// English digits
string english = ShamsiDateFormatter.FormatWithEnglishDigits(date, "yyyy/MM/dd");
// Output: 1403/01/01
```

#### Time Formatting
```csharp
DateTime dateTime = new DateTime(2024, 3, 20, 14, 30, 45);

string withTime = ShamsiDateFormatter.Format(dateTime, "yyyy/MM/dd HH:mm:ss");
// Output: ۱۴۰۳/۰۱/۰۱ ۱۴:۳۰:۴۵

string timeOnly = ShamsiDateFormatter.FormatTime(dateTime, "HH:mm");
// Output: ۱۴:۳۰
```

### 🔍 Date Parsing and Validation (New in v1.9.3)

#### Parse Persian Date Strings
```csharp
using PersianDate;

// Parse various formats
DateTime parsed1 = ShamsiDateParser.Parse("۱۴۰۳/۱/۱");
DateTime parsed2 = ShamsiDateParser.Parse("1403/1/1");
DateTime parsed3 = ShamsiDateParser.Parse("1403-01-01");

// Safe parsing with TryParse
if (ShamsiDateParser.TryParse("۱۴۰۳/۱۲/۲۹", out DateTime result))
{
    Console.WriteLine($"Parsed: {result}");
}

// Strict validation
var validation = ShamsiDateParser.ParseAndValidate("1403/13/1");
if (!validation.IsValid)
{
    Console.WriteLine($"Error: {validation.ErrorMessage}");
    // Output: Error: Month must be between 1 and 12
}
```

#### Validation Options
```csharp
// Different validation modes
bool isValid1 = ShamsiDateParser.IsValidShamsiDate(1403, 12, 30); // false (invalid day)
bool isValid2 = ShamsiDateParser.IsValidShamsiDate(1403, 6, 31);  // false (month 6 has max 31 days)
bool isValid3 = ShamsiDateParser.IsValidShamsiDate(1403, 1, 31);  // true

// Parse with custom validation
var strictResult = ShamsiDateParser.ParseAndValidate("1403/12/30", ValidationMode.Strict);
var lenientResult = ShamsiDateParser.ParseAndValidate("1403/12/30", ValidationMode.Lenient);
```

### 🌐 Localization and Culture Support (New in v1.9.3)

#### Persian Culture
```csharp
using PersianDate;

DateTime date = new DateTime(2024, 3, 20);
var persianCulture = ShamsiCultureInfo.Persian;

// Persian formatting with Persian digits and month names
string persian = ShamsiLocalizedFormatter.Format(date, "dd MMMM yyyy", persianCulture);
// Output: ۰۱ فروردین ۱۴۰۳

// Extension method for Persian culture
string persianExt = date.ToShamsiString(ShamsiFormatStyle.Long, persianCulture);
// Output: ۱ فروردین ۱۴۰۳
```

#### English Culture
```csharp
var englishCulture = ShamsiCultureInfo.English;

// English formatting with English digits and transliterated names
string english = ShamsiLocalizedFormatter.Format(date, "dd MMMM yyyy", englishCulture);
// Output: 01 Farvardin 1403

// Extension method for English culture
string englishExt = date.ToShamsiString(ShamsiFormatStyle.Full, englishCulture);
// Output: Wednesday, 1 Farvardin 1403
```

#### Culture-Specific Properties
```csharp
// Persian culture properties
Console.WriteLine(persianCulture.DisplayName);        // فارسی (ایران)
Console.WriteLine(persianCulture.IsRightToLeft);      // true
Console.WriteLine(persianCulture.UsesPersianDigits);  // true
Console.WriteLine(persianCulture.DateSeparator);      // /

// English culture properties  
Console.WriteLine(englishCulture.DisplayName);        // English
Console.WriteLine(englishCulture.IsRightToLeft);      // false
Console.WriteLine(englishCulture.UsesPersianDigits);  // false
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

// New localized extensions
Console.WriteLine(dateTime.ToShamsiString(ShamsiFormatStyle.Full, ShamsiCultureInfo.English));
// Output: Thursday, 13 Mehr 1402
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

- .NET 6.0
- .NET 7.0
- .NET 8.0
- .NET 9.0

## 📚 API Reference

### ShamsiDateFormatter
- `Format(DateTime, ShamsiFormatStyle)` - Format with predefined styles
- `Format(DateTime, string)` - Format with custom pattern (Persian digits)
- `FormatWithEnglishDigits(DateTime, string)` - Format with English digits
- `FormatTime(DateTime, string)` - Format time components only
- `ConvertToPersianDigits(string)` - Convert English to Persian digits

### ShamsiDateParser
- `Parse(string)` - Parse Persian date string to DateTime
- `TryParse(string, out DateTime)` - Safe parsing with boolean result
- `ParseAndValidate(string, ValidationMode?)` - Parse with validation details
- `IsValidShamsiDate(int year, int month, int day)` - Validate date components

### ShamsiCultureInfo
- `Persian` - Persian culture (fa-IR) with Persian digits and RTL support
- `English` - English culture (en-US) with English digits and transliterated names
- `CreateCulture(string)` - Create custom culture

### ShamsiLocalizedFormatter
- `Format(DateTime, string, ShamsiCultureInfo)` - Culture-aware formatting

### Extension Methods
- `ToShamsiString(ShamsiFormatStyle, ShamsiCultureInfo?)` - Convert to localized Shamsi string
- `ToShamsiDate()` - Convert to basic Shamsi date string
- `ToShortShamsiDate()` - Convert to short format
- `ToLongShamsiDate()` - Convert to long format with day name

### Format Patterns
| Pattern | Description | Example (Persian) | Example (English) |
|---------|-------------|-------------------|-------------------|
| `yyyy` | 4-digit year | ۱۴۰۳ | 1403 |
| `yy` | 2-digit year | ۰۳ | 03 |
| `MMMM` | Full month name | فروردین | Farvardin |
| `MMM` | Abbreviated month | فرو | Far |
| `MM` | 2-digit month | ۰۱ | 01 |
| `M` | Month number | ۱ | 1 |
| `dddd` | Full day name | چهارشنبه | Wednesday |
| `ddd` | Abbreviated day | چهار | Wed |
| `dd` | 2-digit day | ۰۱ | 01 |
| `d` | Day number | ۱ | 1 |
| `HH` | 24-hour format | ۱۴ | 14 |
| `mm` | Minutes | ۳۰ | 30 |
| `ss` | Seconds | ۴۵ | 45 |

## 🏗️ Project Structure

```
PersianDate/
├── Core/                    # Core date conversion functionality
│   ├── PersianDateShamsi.cs    # Main Persian date conversion class
│   ├── ToGregorian.cs          # Gregorian conversion utilities
│   └── ToShamsi.cs            # Extension methods for conversion
├── Formatting/              # Enhanced formatting features
│   └── ShamsiDateFormatter.cs  # Advanced formatting with styles and patterns
├── Parsing/                 # Date parsing and validation
│   └── ShamsiDateParser.cs     # Parse Persian date strings with validation
├── Culture/                 # Localization and culture support
│   └── ShamsiCultureInfo.cs    # Persian and English culture definitions
├── Extensions/              # Extension methods and operations
│   ├── ShamsiCalendarExtensions.cs   # DateTime extension methods
│   └── ShamsiCalendarOperations.cs   # Advanced calendar operations
└── Utils/                   # Utility classes
    └── StringUtil.cs           # String manipulation utilities
```

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

| Version | Changes                                                                                                                    |
| ------- | -------------------------------------------------------------------------------------------------------------------------- |
| 1.9.3   | **🚀 Major Feature Release**: Enhanced Formatting Options, Date Parsing & Validation, Localization & Culture Support with 191 comprehensive tests |
| 1.9.2   | Remove .NET 5.0 support and modernize CI/CD workflows with automated changelog generation                                  |
| 1.9.1   | Add support for older .NET versions (netstandard2.0, netstandard2.1, netcoreapp3.1) and .NET 9.0                           |
| 1.0.9   | Upgraded to .NET 9.0                                                                                                       |
| 1.0.8   | Added support for `DateTimeOffset` in `ToGregorian` class and updated `PersianDateShamsi.cs` and `ToShamsi.cs` accordingly |
| 1.0.6   | Added support for .NET 8.0                                                                                                 |
| 1.0.4   | Added support for .NET 5.0 and 6.0                                                                                         |
| 1.0.3   | Changed from .NET Standard 2.0 to .NET 7.0                                                                                 |
| 1.0.2   | Improved flexibility                                                                                                       |
| 1.0.1   | Changed from .NET Standard 2.1 to 2.0 for broader platform support                                                         |

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

If you encounter any issues or have questions, please [open an issue](https://github.com/hootanht/PersianDate/issues) on GitHub.

---

Made with ❤️ by [Hootan Hemmati](https://github.com/hootanht)
