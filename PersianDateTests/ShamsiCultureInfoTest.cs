using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using PersianDate;

namespace PersianDateTests;

[TestClass]
public class ShamsiCultureInfoTest
{
    private readonly DateTime testDate = new(2024, 3, 20); // 1 Farvardin 1403

    [TestMethod]
    public void Persian_ShouldHaveCorrectProperties()
    {
        // Act
        var culture = ShamsiCultureInfo.Persian;

        // Assert
        Assert.AreEqual("fa-IR", culture.CultureCode);
        Assert.AreEqual("فارسی (ایران)", culture.DisplayName);
        Assert.IsTrue(culture.UsesPersianDigits);
        Assert.IsTrue(culture.IsRightToLeft);
        Assert.AreEqual("/", culture.DateSeparator);
        Assert.AreEqual(":", culture.TimeSeparator);
    }

    [TestMethod]
    public void English_ShouldHaveCorrectProperties()
    {
        // Act
        var culture = ShamsiCultureInfo.English;

        // Assert
        Assert.AreEqual("en-US", culture.CultureCode);
        Assert.AreEqual("English", culture.DisplayName);
        Assert.IsFalse(culture.UsesPersianDigits);
        Assert.IsFalse(culture.IsRightToLeft);
        Assert.AreEqual("/", culture.DateSeparator);
        Assert.AreEqual(":", culture.TimeSeparator);
    }

    [TestMethod]
    public void Persian_MonthNames_ShouldBeInPersian()
    {
        // Arrange
        var culture = ShamsiCultureInfo.Persian;

        // Act & Assert
        Assert.AreEqual("فروردین", culture.MonthNames[1]);
        Assert.AreEqual("اردیبهشت", culture.MonthNames[2]);
        Assert.AreEqual("خرداد", culture.MonthNames[3]);
        Assert.AreEqual("تیر", culture.MonthNames[4]);
        Assert.AreEqual("مرداد", culture.MonthNames[5]);
        Assert.AreEqual("شهریور", culture.MonthNames[6]);
        Assert.AreEqual("مهر", culture.MonthNames[7]);
        Assert.AreEqual("آبان", culture.MonthNames[8]);
        Assert.AreEqual("آذر", culture.MonthNames[9]);
        Assert.AreEqual("دی", culture.MonthNames[10]);
        Assert.AreEqual("بهمن", culture.MonthNames[11]);
        Assert.AreEqual("اسفند", culture.MonthNames[12]);
    }

    [TestMethod]
    public void English_MonthNames_ShouldBeInEnglish()
    {
        // Arrange
        var culture = ShamsiCultureInfo.English;

        // Act & Assert
        Assert.AreEqual("Farvardin", culture.MonthNames[1]);
        Assert.AreEqual("Ordibehesht", culture.MonthNames[2]);
        Assert.AreEqual("Khordad", culture.MonthNames[3]);
        Assert.AreEqual("Tir", culture.MonthNames[4]);
        Assert.AreEqual("Mordad", culture.MonthNames[5]);
        Assert.AreEqual("Shahrivar", culture.MonthNames[6]);
        Assert.AreEqual("Mehr", culture.MonthNames[7]);
        Assert.AreEqual("Aban", culture.MonthNames[8]);
        Assert.AreEqual("Azar", culture.MonthNames[9]);
        Assert.AreEqual("Dey", culture.MonthNames[10]);
        Assert.AreEqual("Bahman", culture.MonthNames[11]);
        Assert.AreEqual("Esfand", culture.MonthNames[12]);
    }

    [TestMethod]
    public void Persian_DayNames_ShouldBeInPersian()
    {
        // Arrange
        var culture = ShamsiCultureInfo.Persian;

        // Act & Assert
        Assert.AreEqual("شنبه", culture.DayNames[DayOfWeek.Saturday]);
        Assert.AreEqual("یکشنبه", culture.DayNames[DayOfWeek.Sunday]);
        Assert.AreEqual("دوشنبه", culture.DayNames[DayOfWeek.Monday]);
        Assert.AreEqual("سه‌شنبه", culture.DayNames[DayOfWeek.Tuesday]);
        Assert.AreEqual("چهارشنبه", culture.DayNames[DayOfWeek.Wednesday]);
        Assert.AreEqual("پنج‌شنبه", culture.DayNames[DayOfWeek.Thursday]);
        Assert.AreEqual("جمعه", culture.DayNames[DayOfWeek.Friday]);
    }

    [TestMethod]
    public void CreateCulture_ValidCultureCode_ShouldCreateCorrectly()
    {
        // Act
        var persianCulture = ShamsiCultureInfo.CreateCulture("fa-IR");
        var englishCulture = ShamsiCultureInfo.CreateCulture("en-US");

        // Assert
        Assert.AreEqual("fa-IR", persianCulture.CultureCode);
        Assert.IsTrue(persianCulture.UsesPersianDigits);
        
        Assert.AreEqual("en-US", englishCulture.CultureCode);
        Assert.IsFalse(englishCulture.UsesPersianDigits);
    }
}

[TestClass]
public class ShamsiLocalizedFormatterTest
{
    private readonly DateTime testDate = new(2024, 3, 20); // 1 Farvardin 1403

    [TestMethod]
    public void Format_PersianCulture_ShouldReturnPersianFormat()
    {
        // Arrange
        var culture = ShamsiCultureInfo.Persian;

        // Act
        string result = ShamsiLocalizedFormatter.Format(testDate, "yyyy/MM/dd", culture);

        // Assert
        Assert.AreEqual("۱۴۰۳/۰۱/۰۱", result);
    }

    [TestMethod]
    public void Format_EnglishCulture_ShouldReturnEnglishFormat()
    {
        // Arrange
        var culture = ShamsiCultureInfo.English;

        // Act
        string result = ShamsiLocalizedFormatter.Format(testDate, "yyyy/MM/dd", culture);

        // Assert
        Assert.AreEqual("1403/01/01", result);
    }

    [TestMethod]
    public void Format_PersianCultureWithMonthName_ShouldUsePersianMonthName()
    {
        // Arrange
        var culture = ShamsiCultureInfo.Persian;

        // Act
        string result = ShamsiLocalizedFormatter.Format(testDate, "dd MMMM yyyy", culture);

        // Assert
        Assert.AreEqual("۰۱ فروردین ۱۴۰۳", result);
    }

    [TestMethod]
    public void Format_EnglishCultureWithMonthName_ShouldUseEnglishMonthName()
    {
        // Arrange
        var culture = ShamsiCultureInfo.English;

        // Act
        string result = ShamsiLocalizedFormatter.Format(testDate, "dd MMMM yyyy", culture);

        // Assert
        Assert.AreEqual("01 Farvardin 1403", result);
    }

    [TestMethod]
    public void Format_PredefinedStyleShort_ShouldUseCorrectSeparator()
    {
        // Arrange
        var persianCulture = ShamsiCultureInfo.Persian;
        var englishCulture = ShamsiCultureInfo.English;

        // Act
        string persianResult = ShamsiLocalizedFormatter.Format(testDate, ShamsiDateFormatStyle.Short, persianCulture);
        string englishResult = ShamsiLocalizedFormatter.Format(testDate, ShamsiDateFormatStyle.Short, englishCulture);

        // Assert
        Assert.AreEqual("۱۴۰۳/۰۱/۰۱", persianResult);
        Assert.AreEqual("1403/01/01", englishResult);
    }

    [TestMethod]
    public void Format_PredefinedStyleFull_ShouldHandleRightToLeft()
    {
        // Arrange
        var persianCulture = ShamsiCultureInfo.Persian;
        var englishCulture = ShamsiCultureInfo.English;

        // Act
        string persianResult = ShamsiLocalizedFormatter.Format(testDate, ShamsiDateFormatStyle.Full, persianCulture);
        string englishResult = ShamsiLocalizedFormatter.Format(testDate, ShamsiDateFormatStyle.Full, englishCulture);

        // Assert
        Assert.IsTrue(persianResult.Contains("،")); // Persian comma
        Assert.IsTrue(englishResult.Contains(",")); // English comma
    }

    [TestMethod]
    public void GetLocalizedMonthName_AllMonths_ShouldReturnCorrectNames()
    {
        // Arrange
        var persianCulture = ShamsiCultureInfo.Persian;
        var englishCulture = ShamsiCultureInfo.English;

        // Act & Assert
        for (int month = 1; month <= 12; month++)
        {
            string persianName = ShamsiLocalizedFormatter.GetLocalizedMonthName(month, persianCulture);
            string englishName = ShamsiLocalizedFormatter.GetLocalizedMonthName(month, englishCulture);
            
            Assert.IsFalse(string.IsNullOrEmpty(persianName));
            Assert.IsFalse(string.IsNullOrEmpty(englishName));
            
            // Persian should contain Persian characters
            if (month == 1)
            {
                Assert.AreEqual("فروردین", persianName);
                Assert.AreEqual("Farvardin", englishName);
            }
        }
    }

    [TestMethod]
    public void GetLocalizedMonthName_Abbreviated_ShouldReturnShortNames()
    {
        // Arrange
        var persianCulture = ShamsiCultureInfo.Persian;
        var englishCulture = ShamsiCultureInfo.English;

        // Act
        string persianAbbr = ShamsiLocalizedFormatter.GetLocalizedMonthName(1, persianCulture, abbreviated: true);
        string englishAbbr = ShamsiLocalizedFormatter.GetLocalizedMonthName(1, englishCulture, abbreviated: true);

        // Assert
        Assert.AreEqual("فرو", persianAbbr);
        Assert.AreEqual("Far", englishAbbr);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetLocalizedMonthName_InvalidMonth_ShouldThrowException()
    {
        // Arrange
        var culture = ShamsiCultureInfo.Persian;

        // Act
        ShamsiLocalizedFormatter.GetLocalizedMonthName(13, culture);
    }

    [TestMethod]
    public void GetLocalizedDayName_AllDays_ShouldReturnCorrectNames()
    {
        // Arrange
        var persianCulture = ShamsiCultureInfo.Persian;
        var englishCulture = ShamsiCultureInfo.English;

        // Act & Assert
        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            string persianName = ShamsiLocalizedFormatter.GetLocalizedDayName(day, persianCulture);
            string englishName = ShamsiLocalizedFormatter.GetLocalizedDayName(day, englishCulture);
            
            Assert.IsFalse(string.IsNullOrEmpty(persianName));
            Assert.IsFalse(string.IsNullOrEmpty(englishName));
        }
    }

    [TestMethod]
    public void LocalizeDigits_PersianCulture_ShouldConvertToPersian()
    {
        // Arrange
        var culture = ShamsiCultureInfo.Persian;
        string input = "1403/01/15";

        // Act
        string result = ShamsiLocalizedFormatter.LocalizeDigits(input, culture);

        // Assert
        Assert.AreEqual("۱۴۰۳/۰۱/۱۵", result);
    }

    [TestMethod]
    public void LocalizeDigits_EnglishCulture_ShouldKeepArabicDigits()
    {
        // Arrange
        var culture = ShamsiCultureInfo.English;
        string input = "۱۴۰۳/۰۱/۱۵";

        // Act
        string result = ShamsiLocalizedFormatter.LocalizeDigits(input, culture);

        // Assert
        Assert.AreEqual("1403/01/15", result);
    }

    [TestMethod]
    public void GetAvailableCultures_ShouldReturnExpectedCultures()
    {
        // Act
        var cultures = ShamsiLocalizedFormatter.GetAvailableCultures();

        // Assert
        Assert.AreEqual(2, cultures.Count);
        Assert.IsTrue(cultures.Any(c => c.CultureCode == "fa-IR"));
        Assert.IsTrue(cultures.Any(c => c.CultureCode == "en-US"));
    }

    [TestMethod]
    public void GetCultureDatePatterns_ShouldReturnCorrectPatterns()
    {
        // Arrange
        var persianCulture = ShamsiCultureInfo.Persian;
        var englishCulture = ShamsiCultureInfo.English;

        // Act
        var persianPatterns = ShamsiLocalizedFormatter.GetCultureDatePatterns(persianCulture);
        var englishPatterns = ShamsiLocalizedFormatter.GetCultureDatePatterns(englishCulture);

        // Assert
        Assert.IsTrue(persianPatterns.ContainsKey("ShortDate"));
        Assert.IsTrue(persianPatterns.ContainsKey("LongDate"));
        Assert.IsTrue(englishPatterns.ContainsKey("ShortDate"));
        Assert.IsTrue(englishPatterns.ContainsKey("LongDate"));
        
        Assert.AreEqual("yyyy/MM/dd", persianPatterns["ShortDate"]);
        Assert.AreEqual("yyyy/MM/dd", englishPatterns["ShortDate"]);
    }
}

[TestClass]
public class ShamsiLocalizationExtensionsTest
{
    private readonly DateTime testDate = new(2024, 3, 20); // 1 Farvardin 1403

    [TestMethod]
    public void ToShamsiString_WithFormat_ShouldReturnFormattedString()
    {
        // Arrange
        var culture = ShamsiCultureInfo.Persian;

        // Act
        string result = testDate.ToShamsiString("yyyy/MM/dd", culture);

        // Assert
        Assert.AreEqual("۱۴۰۳/۰۱/۰۱", result);
    }

    [TestMethod]
    public void ToShamsiString_WithStyle_ShouldReturnFormattedString()
    {
        // Arrange
        var culture = ShamsiCultureInfo.Persian;

        // Act
        string result = testDate.ToShamsiString(ShamsiDateFormatStyle.Medium, culture);

        // Assert
        Assert.AreEqual("۰۱ فروردین ۱۴۰۳", result);
    }

    [TestMethod]
    public void ToShamsiStringPersian_ShouldUsePersianCulture()
    {
        // Act
        string result = testDate.ToShamsiStringPersian();

        // Assert
        Assert.IsTrue(result.Contains("فروردین"));
        Assert.IsTrue(result.Contains("۱۴۰۳"));
    }

    [TestMethod]
    public void ToShamsiStringEnglish_ShouldUseEnglishCulture()
    {
        // Act
        string result = testDate.ToShamsiStringEnglish();

        // Assert
        Assert.IsTrue(result.Contains("Farvardin"));
        Assert.IsTrue(result.Contains("1403"));
    }

    [TestMethod]
    public void ToShamsiStringPersian_DifferentStyles_ShouldReturnCorrectFormats()
    {
        // Act
        string shortResult = testDate.ToShamsiStringPersian(ShamsiDateFormatStyle.Short);
        string mediumResult = testDate.ToShamsiStringPersian(ShamsiDateFormatStyle.Medium);
        string longResult = testDate.ToShamsiStringPersian(ShamsiDateFormatStyle.Long);

        // Assert
        Assert.AreEqual("۱۴۰۳/۰۱/۰۱", shortResult);
        Assert.AreEqual("۰۱ فروردین ۱۴۰۳", mediumResult);
        Assert.IsTrue(longResult.Contains("فروردین"));
        Assert.IsTrue(longResult.Length > mediumResult.Length); // Long format should be longer
    }

    [TestMethod]
    public void ToShamsiStringEnglish_DifferentStyles_ShouldReturnCorrectFormats()
    {
        // Act
        string shortResult = testDate.ToShamsiStringEnglish(ShamsiDateFormatStyle.Short);
        string mediumResult = testDate.ToShamsiStringEnglish(ShamsiDateFormatStyle.Medium);
        string longResult = testDate.ToShamsiStringEnglish(ShamsiDateFormatStyle.Long);

        // Assert
        Assert.AreEqual("1403/01/01", shortResult);
        Assert.AreEqual("01 Farvardin 1403", mediumResult);
        Assert.IsTrue(longResult.Contains("Farvardin"));
        Assert.IsTrue(longResult.Length > mediumResult.Length); // Long format should be longer
    }

    [TestMethod]
    public void ExtensionMethods_DifferentDates_ShouldFormatCorrectly()
    {
        // Arrange
        var springDate = new DateTime(2024, 3, 20); // 1 Farvardin 1403
        var summerDate = new DateTime(2024, 7, 15); // Around 25 Tir 1403
        var winterDate = new DateTime(2024, 12, 20); // Around 30 Azar 1403

        // Act
        string springPersian = springDate.ToShamsiStringPersian();
        string summerEnglish = summerDate.ToShamsiStringEnglish();
        string winterPersian = winterDate.ToShamsiStringPersian();

        // Assert
        Assert.IsTrue(springPersian.Contains("فروردین"));
        Assert.IsTrue(summerEnglish.Contains("Tir") || summerEnglish.Contains("Mordad"));
        Assert.IsTrue(winterPersian.Contains("آذر") || winterPersian.Contains("دی"));
    }

    [TestMethod]
    public void Performance_FormatManyDatesWithCulture_ShouldCompleteQuickly()
    {
        // Arrange
        var startTime = DateTime.UtcNow;
        var dates = new List<DateTime>();
        var culture = ShamsiCultureInfo.Persian;
        
        for (int i = 0; i < 1000; i++)
        {
            dates.Add(testDate.AddDays(i));
        }

        // Act
        foreach (var date in dates)
        {
            date.ToShamsiString(ShamsiDateFormatStyle.Medium, culture);
        }

        // Assert
        var elapsed = DateTime.UtcNow - startTime;
        Assert.IsTrue(elapsed.TotalMilliseconds < 5000, $"Formatting took too long: {elapsed.TotalMilliseconds}ms");
    }

    [TestMethod]
    public void IntegrationTest_AllFeaturesTogether_ShouldWorkCorrectly()
    {
        // Arrange
        var persianCulture = ShamsiCultureInfo.Persian;
        var englishCulture = ShamsiCultureInfo.English;

        // Act - Test all features together
        string persianShort = testDate.ToShamsiString(ShamsiDateFormatStyle.Short, persianCulture);
        string englishLong = testDate.ToShamsiString(ShamsiDateFormatStyle.Long, englishCulture);
        string customFormat = testDate.ToShamsiString("dddd، dd MMMM yyyy", persianCulture);

        // Assert
        Assert.AreEqual("۱۴۰۳/۰۱/۰۱", persianShort);
        Assert.IsTrue(englishLong.Contains("Farvardin"));
        Assert.IsTrue(customFormat.Contains("،"));
        Assert.IsTrue(customFormat.Contains("فروردین"));
    }
}
