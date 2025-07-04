using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using PersianDate.Formatting;

namespace PersianDate.Culture;

/// <summary>
/// Provides localization and culture support for Persian/Shamsi dates.
/// </summary>
public class ShamsiCultureInfo
{
    /// <summary>
    /// Gets the default Persian culture settings.
    /// </summary>
    public static ShamsiCultureInfo Persian => new("fa-IR");
    
    /// <summary>
    /// Gets the English culture settings for Persian dates.
    /// </summary>
    public static ShamsiCultureInfo English => new("en-US");
    
    /// <summary>
    /// Gets the current culture identifier.
    /// </summary>
    public string CultureCode { get; }
    
    /// <summary>
    /// Gets the display name of the culture.
    /// </summary>
    public string DisplayName { get; }
    
    /// <summary>
    /// Gets the month names for this culture.
    /// </summary>
    public IReadOnlyDictionary<int, string> MonthNames { get; }
    
    /// <summary>
    /// Gets the abbreviated month names for this culture.
    /// </summary>
    public IReadOnlyDictionary<int, string> AbbreviatedMonthNames { get; }
    
    /// <summary>
    /// Gets the day names for this culture.
    /// </summary>
    public IReadOnlyDictionary<DayOfWeek, string> DayNames { get; }
    
    /// <summary>
    /// Gets the abbreviated day names for this culture.
    /// </summary>
    public IReadOnlyDictionary<DayOfWeek, string> AbbreviatedDayNames { get; }
    
    /// <summary>
    /// Gets whether this culture uses Persian digits.
    /// </summary>
    public bool UsesPersianDigits { get; }
    
    /// <summary>
    /// Gets the date separator for this culture.
    /// </summary>
    public string DateSeparator { get; }
    
    /// <summary>
    /// Gets the time separator for this culture.
    /// </summary>
    public string TimeSeparator { get; }
    
    /// <summary>
    /// Gets whether dates are written right-to-left.
    /// </summary>
    public bool IsRightToLeft { get; }

    private ShamsiCultureInfo(string cultureCode)
    {
        CultureCode = cultureCode;
        
        switch (cultureCode.ToLowerInvariant())
        {
            case "fa-ir":
            case "fa":
                DisplayName = "فارسی (ایران)";
                MonthNames = PersianMonthNames;
                AbbreviatedMonthNames = PersianAbbreviatedMonthNames;
                DayNames = PersianDayNames;
                AbbreviatedDayNames = PersianAbbreviatedDayNames;
                UsesPersianDigits = true;
                DateSeparator = "/";
                TimeSeparator = ":";
                IsRightToLeft = true;
                break;
                
            case "en-us":
            case "en":
            default:
                DisplayName = "English";
                MonthNames = EnglishMonthNames;
                AbbreviatedMonthNames = EnglishAbbreviatedMonthNames;
                DayNames = EnglishDayNames;
                AbbreviatedDayNames = EnglishAbbreviatedDayNames;
                UsesPersianDigits = false;
                DateSeparator = "/";
                TimeSeparator = ":";
                IsRightToLeft = false;
                break;
        }
    }

    private static readonly Dictionary<int, string> PersianMonthNames = new()
    {
        { 1, "فروردین" }, { 2, "اردیبهشت" }, { 3, "خرداد" },
        { 4, "تیر" }, { 5, "مرداد" }, { 6, "شهریور" },
        { 7, "مهر" }, { 8, "آبان" }, { 9, "آذر" },
        { 10, "دی" }, { 11, "بهمن" }, { 12, "اسفند" }
    };

    private static readonly Dictionary<int, string> PersianAbbreviatedMonthNames = new()
    {
        { 1, "فرو" }, { 2, "ارد" }, { 3, "خرد" },
        { 4, "تیر" }, { 5, "مرد" }, { 6, "شهر" },
        { 7, "مهر" }, { 8, "آبا" }, { 9, "آذر" },
        { 10, "دی" }, { 11, "بهم" }, { 12, "اسف" }
    };

    private static readonly Dictionary<DayOfWeek, string> PersianDayNames = new()
    {
        { DayOfWeek.Saturday, "شنبه" }, { DayOfWeek.Sunday, "یکشنبه" }, 
        { DayOfWeek.Monday, "دوشنبه" }, { DayOfWeek.Tuesday, "سه‌شنبه" },
        { DayOfWeek.Wednesday, "چهارشنبه" }, { DayOfWeek.Thursday, "پنج‌شنبه" },
        { DayOfWeek.Friday, "جمعه" }
    };

    private static readonly Dictionary<DayOfWeek, string> PersianAbbreviatedDayNames = new()
    {
        { DayOfWeek.Saturday, "ش" }, { DayOfWeek.Sunday, "ی" }, 
        { DayOfWeek.Monday, "د" }, { DayOfWeek.Tuesday, "س" },
        { DayOfWeek.Wednesday, "چ" }, { DayOfWeek.Thursday, "پ" },
        { DayOfWeek.Friday, "ج" }
    };

    private static readonly Dictionary<int, string> EnglishMonthNames = new()
    {
        { 1, "Farvardin" }, { 2, "Ordibehesht" }, { 3, "Khordad" },
        { 4, "Tir" }, { 5, "Mordad" }, { 6, "Shahrivar" },
        { 7, "Mehr" }, { 8, "Aban" }, { 9, "Azar" },
        { 10, "Dey" }, { 11, "Bahman" }, { 12, "Esfand" }
    };

    private static readonly Dictionary<int, string> EnglishAbbreviatedMonthNames = new()
    {
        { 1, "Far" }, { 2, "Ord" }, { 3, "Kho" },
        { 4, "Tir" }, { 5, "Mor" }, { 6, "Sha" },
        { 7, "Meh" }, { 8, "Aba" }, { 9, "Aza" },
        { 10, "Dey" }, { 11, "Bah" }, { 12, "Esf" }
    };

    private static readonly Dictionary<DayOfWeek, string> EnglishDayNames = new()
    {
        { DayOfWeek.Saturday, "Saturday" }, { DayOfWeek.Sunday, "Sunday" }, 
        { DayOfWeek.Monday, "Monday" }, { DayOfWeek.Tuesday, "Tuesday" },
        { DayOfWeek.Wednesday, "Wednesday" }, { DayOfWeek.Thursday, "Thursday" },
        { DayOfWeek.Friday, "Friday" }
    };

    private static readonly Dictionary<DayOfWeek, string> EnglishAbbreviatedDayNames = new()
    {
        { DayOfWeek.Saturday, "Sat" }, { DayOfWeek.Sunday, "Sun" }, 
        { DayOfWeek.Monday, "Mon" }, { DayOfWeek.Tuesday, "Tue" },
        { DayOfWeek.Wednesday, "Wed" }, { DayOfWeek.Thursday, "Thu" },
        { DayOfWeek.Friday, "Fri" }
    };

    /// <summary>
    /// Creates a culture info for the specified culture code.
    /// </summary>
    /// <param name="cultureCode">The culture code (e.g., "fa-IR", "en-US").</param>
    /// <returns>A ShamsiCultureInfo instance.</returns>
    public static ShamsiCultureInfo CreateCulture(string cultureCode)
    {
        return new ShamsiCultureInfo(cultureCode);
    }
}

/// <summary>
/// Provides localized formatting for Persian/Shamsi dates.
/// </summary>
public static class ShamsiLocalizedFormatter
{
    /// <summary>
    /// Formats a DateTime using the specified culture.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="format">The format pattern.</param>
    /// <param name="culture">The culture to use for formatting.</param>
    /// <returns>The formatted date string.</returns>
    public static string Format(DateTime date, string format, ShamsiCultureInfo culture)
    {
        var pc = new PersianCalendar();
        int year = pc.GetYear(date);
        int month = pc.GetMonth(date);
        int day = pc.GetDayOfMonth(date);
        DayOfWeek dayOfWeek = pc.GetDayOfWeek(date);

        string result = format;

        // Use special placeholders that contain NO format characters (y, M, d)
        var yearPlaceholder = "⟪ⓎⒺⒶⓇ④⟫";
        var year2Placeholder = "⟪ⓎⒺⒶⓇ②⟫";
        var monthFullPlaceholder = "⟪ⓜⓞⓝⓣⓗⓕⓤⓛⓛ⟫";
        var monthAbbrPlaceholder = "⟪ⓜⓞⓝⓣⓗⓐⓑⓑⓡ⟫";
        var month2Placeholder = "⟪ⓜⓞⓝⓣⓗ②⟫";
        var month1Placeholder = "⟪ⓜⓞⓝⓣⓗ①⟫";
        var dayFullPlaceholder = "⟪ⓓⓐⓨⓕⓤⓛⓛ⟫";
        var dayAbbrPlaceholder = "⟪ⓓⓐⓨⓐⓑⓑⓡ⟫";
        var day2Placeholder = "⟪ⓓⓐⓨ②⟫";
        var day1Placeholder = "⟪ⓓⓐⓨ①⟫";

        // First pass: replace patterns with unique placeholders (longest first)
        result = result.Replace("yyyy", yearPlaceholder);
        result = result.Replace("MMMM", monthFullPlaceholder);
        result = result.Replace("dddd", dayFullPlaceholder);
        result = result.Replace("yy", year2Placeholder);
        result = result.Replace("MMM", monthAbbrPlaceholder);
        result = result.Replace("ddd", dayAbbrPlaceholder);
        result = result.Replace("MM", month2Placeholder);
        result = result.Replace("dd", day2Placeholder);
        result = result.Replace("M", month1Placeholder);
        result = result.Replace("d", day1Placeholder);

        // Second pass: replace placeholders with actual values
        result = result.Replace(yearPlaceholder, year.ToString("0000"));
        result = result.Replace(year2Placeholder, (year % 100).ToString("00"));
        result = result.Replace(monthFullPlaceholder, culture.MonthNames[month]);
        result = result.Replace(monthAbbrPlaceholder, culture.AbbreviatedMonthNames[month]);
        result = result.Replace(month2Placeholder, month.ToString("00"));
        result = result.Replace(month1Placeholder, month.ToString());
        result = result.Replace(dayFullPlaceholder, culture.DayNames[dayOfWeek]);
        result = result.Replace(dayAbbrPlaceholder, culture.AbbreviatedDayNames[dayOfWeek]);
        result = result.Replace(day2Placeholder, day.ToString("00"));
        result = result.Replace(day1Placeholder, day.ToString());

        // Apply culture-specific formatting
        if (culture.UsesPersianDigits)
        {
            result = ShamsiDateFormatter.ConvertToPersianDigits(result);
        }

        return result;
    }

    /// <summary>
    /// Formats a DateTime using predefined styles and culture.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="style">The formatting style.</param>
    /// <param name="culture">The culture to use for formatting.</param>
    /// <returns>The formatted date string.</returns>
    public static string Format(DateTime date, ShamsiDateFormatStyle style, ShamsiCultureInfo culture)
    {
        string pattern = style switch
        {
            ShamsiDateFormatStyle.Short => $"yyyy{culture.DateSeparator}MM{culture.DateSeparator}dd",
            ShamsiDateFormatStyle.Medium => "dd MMMM yyyy",
            ShamsiDateFormatStyle.Long => "dddd dd MMMM yyyy",
            ShamsiDateFormatStyle.Full => culture.IsRightToLeft ? "dddd، dd MMMM yyyy" : "dddd, dd MMMM yyyy",
            ShamsiDateFormatStyle.YearMonth => "MMMM yyyy",
            ShamsiDateFormatStyle.MonthDay => "dd MMMM",
            ShamsiDateFormatStyle.ISO => "yyyy-MM-dd",
            _ => $"yyyy{culture.DateSeparator}MM{culture.DateSeparator}dd"
        };

        return Format(date, pattern, culture);
    }

    /// <summary>
    /// Gets localized month name.
    /// </summary>
    /// <param name="month">The month number (1-12).</param>
    /// <param name="culture">The culture for localization.</param>
    /// <param name="abbreviated">Whether to return abbreviated name.</param>
    /// <returns>The localized month name.</returns>
    public static string GetLocalizedMonthName(int month, ShamsiCultureInfo culture, bool abbreviated = false)
    {
        if (month < 1 || month > 12)
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");

        return abbreviated ? culture.AbbreviatedMonthNames[month] : culture.MonthNames[month];
    }

    /// <summary>
    /// Gets localized day name.
    /// </summary>
    /// <param name="dayOfWeek">The day of week.</param>
    /// <param name="culture">The culture for localization.</param>
    /// <param name="abbreviated">Whether to return abbreviated name.</param>
    /// <returns>The localized day name.</returns>
    public static string GetLocalizedDayName(DayOfWeek dayOfWeek, ShamsiCultureInfo culture, bool abbreviated = false)
    {
        return abbreviated ? culture.AbbreviatedDayNames[dayOfWeek] : culture.DayNames[dayOfWeek];
    }

    /// <summary>
    /// Converts numbers in text to the appropriate digit format for the culture.
    /// </summary>
    /// <param name="text">The text containing numbers.</param>
    /// <param name="culture">The target culture.</param>
    /// <returns>The text with culture-appropriate digits.</returns>
    public static string LocalizeDigits(string text, ShamsiCultureInfo culture)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        if (culture.UsesPersianDigits)
        {
            return ShamsiDateFormatter.ConvertToPersianDigits(text);
        }
        else
        {
            return ShamsiDateFormatter.ConvertToArabicDigits(text);
        }
    }

    /// <summary>
    /// Gets all available cultures for Shamsi date formatting.
    /// </summary>
    /// <returns>A list of available culture infos.</returns>
    public static List<ShamsiCultureInfo> GetAvailableCultures()
    {
        return new List<ShamsiCultureInfo>
        {
            ShamsiCultureInfo.Persian,
            ShamsiCultureInfo.English
        };
    }

    /// <summary>
    /// Gets culture-specific date format patterns.
    /// </summary>
    /// <param name="culture">The culture to get patterns for.</param>
    /// <returns>A dictionary of pattern names and their format strings.</returns>
    public static Dictionary<string, string> GetCultureDatePatterns(ShamsiCultureInfo culture)
    {
        var separator = culture.DateSeparator;
        
        return new Dictionary<string, string>
        {
            { "ShortDate", $"yyyy{separator}MM{separator}dd" },
            { "LongDate", "dddd dd MMMM yyyy" },
            { "MediumDate", "dd MMMM yyyy" },
            { "YearMonth", "MMMM yyyy" },
            { "MonthDay", "dd MMMM" },
            { "FullDate", culture.IsRightToLeft ? "dddd، dd MMMM yyyy" : "dddd, dd MMMM yyyy" },
            { "ISO", "yyyy-MM-dd" }
        };
    }
}

/// <summary>
/// Extension methods for localized Shamsi date operations.
/// </summary>
public static class ShamsiLocalizationExtensions
{
    /// <summary>
    /// Formats the DateTime using the specified culture.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="format">The format pattern.</param>
    /// <param name="culture">The culture for formatting.</param>
    /// <returns>The formatted date string.</returns>
    public static string ToShamsiString(this DateTime date, string format, ShamsiCultureInfo culture)
    {
        return ShamsiLocalizedFormatter.Format(date, format, culture);
    }

    /// <summary>
    /// Formats the DateTime using the specified style and culture.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="style">The formatting style.</param>
    /// <param name="culture">The culture for formatting.</param>
    /// <returns>The formatted date string.</returns>
    public static string ToShamsiString(this DateTime date, ShamsiDateFormatStyle style, ShamsiCultureInfo culture)
    {
        return ShamsiLocalizedFormatter.Format(date, style, culture);
    }

    /// <summary>
    /// Formats the DateTime using Persian culture.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="style">The formatting style.</param>
    /// <returns>The formatted date string in Persian.</returns>
    public static string ToShamsiStringPersian(this DateTime date, ShamsiDateFormatStyle style = ShamsiDateFormatStyle.Medium)
    {
        return ShamsiLocalizedFormatter.Format(date, style, ShamsiCultureInfo.Persian);
    }

    /// <summary>
    /// Formats the DateTime using English culture.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="style">The formatting style.</param>
    /// <returns>The formatted date string in English.</returns>
    public static string ToShamsiStringEnglish(this DateTime date, ShamsiDateFormatStyle style = ShamsiDateFormatStyle.Medium)
    {
        return ShamsiLocalizedFormatter.Format(date, style, ShamsiCultureInfo.English);
    }
}
