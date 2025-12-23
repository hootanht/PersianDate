# Persian Date Library - AI Coding Agent Instructions

## Project Overview

This is a .NET library for Persian (Shamsi/Jalali) calendar operations with comprehensive date conversion, formatting, parsing, and localization features. The library targets .NET 6-10 and follows a modular architecture with explicit namespace organization.

## Architecture & Module Structure

### Core Components

- **`Core/`**: Fundamental date conversion logic
  - `PersianDateShamsi.cs` - Main conversion class using .NET's PersianCalendar
  - `ToGregorian.cs` - Gregorian conversion utilities
  - `ToShamsi.cs` - Extension methods for DateTime/DateTimeOffset
- **`Formatting/`**: Advanced formatting with Persian/English digits and custom patterns
- **`Parsing/`**: Date parsing with validation (supports Persian and English digits)
- **`Culture/`**: Localization with Persian (fa-IR) and English (en-US) cultures
- **`Extensions/`**: Calendar operations (leap years, seasons, date arithmetic)
- **`Utils/`**: String manipulation utilities

### Key Design Patterns

- **Explicit null handling**: All methods handle nullable inputs gracefully
- **Dual DateTime support**: All operations support both `DateTime` and `DateTimeOffset`
- **Global using statements**: `GlobalUsings.cs` makes all sub-namespaces available with single `using PersianDate;`
- **Extension method approach**: Core functionality exposed via fluent extension methods
- **Culture-aware formatting**: Supports both Persian digits (۰۱۲...) and English digits (012...)

## Development Workflow

### Build & Test Commands

```powershell
# Essential commands for development
dotnet restore PersianDate.slnx
dotnet build PersianDate.slnx --configuration Release
dotnet test PersianDate.slnx --framework net10.0  # Primary target
dotnet test PersianDate.slnx  # All frameworks (net6.0-net10.0)
```

### Project Configuration

- **Multi-targeting**: net6.0;net7.0;net8.0;net9.0;net10.0 (update both projects)
- **Nullable enabled**: All code uses nullable reference types
- **LangVersion**: Latest C# features (currently 13.0)
- **ImplicitUsings disabled**: Explicit using statements required
- **Test framework**: MSTest with coverlet for coverage

## Code Conventions

### Method Patterns

- **Consistent naming**: `GetShamsi[Component]()` for extraction, `ToShamsi[Format]()` for formatting
- **Null-safe methods**: Return `null` for null inputs, throw `ArgumentOutOfRangeException` for invalid dates
- **String formatting**: Use `ToString("00")` for zero-padded numbers
- **Extension methods**: Place in appropriate namespace (`Core`, `Extensions`, `Formatting`)

### Error Handling

```csharp
// Standard pattern for date operations
try
{
    return persianCalendar.GetYear(dateTime.Value);
}
catch (ArgumentOutOfRangeException)
{
    return null;  // Graceful degradation for out-of-range dates
}
```

### Testing Patterns

- **MSTest framework**: Use `[TestClass]` and `[TestMethod]` attributes
- **Descriptive test names**: Include expected behavior and input type
- **Real date testing**: Use actual dates (e.g., author's birthday 1998-01-11 → 1376 Shamsi)
- **Comprehensive coverage**: Test all frameworks, null cases, and edge conditions

## Key Integration Points

### PersianCalendar Dependency

- All date operations use .NET's `System.Globalization.PersianCalendar`
- CultureInfo operations use `CultureInfo.CreateSpecificCulture("fa")` for Persian formatting

### Extension Method Registration

- DateTime extensions in `ToShamsi.cs` and `ShamsiCalendarExtensions.cs`
- DateTimeOffset extensions follow same patterns with wrapper methods

## Common Operations

### Adding New Formatting Options

1. Update `ShamsiDateFormatter.cs` with new patterns
2. Add corresponding extension methods to `ShamsiCalendarExtensions.cs`
3. Create comprehensive tests in `ShamsiDateFormatterTest.cs`
4. Update culture dictionaries if adding new localized strings

### Adding New Calendar Operations

1. Implement core logic in `ShamsiCalendarOperations.cs`
2. Add extension methods to `ShamsiCalendarExtensions.cs` for both DateTime and DateTimeOffset
3. Follow the dual-support pattern for nullable inputs
4. Add validation tests covering edge cases (leap years, month boundaries)

### Package Maintenance

- Version in `PersianDate.csproj` drives NuGet package version
- Update README.md with new features and version history
- Ensure CI/CD passes on all target frameworks before release

## Dependencies & Constraints

- **No external dependencies**: Only uses .NET BCL components
- **Reproducible builds**: Uses DotNet.ReproducibleBuilds package
- **Cross-platform**: Tested on macOS in CI, supports all .NET platforms
- **Persian calendar limits**: Respect .NET PersianCalendar date range limitations
