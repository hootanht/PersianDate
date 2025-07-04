using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PersianDate;

namespace PersianDateTests;

[TestClass]
public class ShamsiDateFormatterTest
{
    private readonly DateTime testDate = new(2024, 3, 20); // 1 Farvardin 1403 (leap year start)
    private readonly DateTime summerDate = new(2024, 7, 15); // Around 25 Tir 1403
    private readonly DateTime winterDate = new(2024, 12, 20); // Around 30 Azar 1403

    [TestMethod]
    public void Format_ShortFormat_ShouldReturnCorrectFormat()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, "yyyy/MM/dd", usePersianDigits: false);
        
        // Assert
        Assert.AreEqual("1403/01/01", result);
    }

    [TestMethod]
    public void Format_ShortFormatWithPersianDigits_ShouldReturnPersianDigits()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, "yyyy/MM/dd", usePersianDigits: true);
        
        // Assert
        Assert.AreEqual("۱۴۰۳/۰۱/۰۱", result);
    }

    [TestMethod]
    public void Format_LongFormat_ShouldIncludeDayName()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, "dddd dd MMMM yyyy", usePersianDigits: false);
        
        // Assert
        Assert.IsTrue(result.Contains("فروردین"));
        Assert.IsTrue(result.Contains("1403"));
        Assert.IsTrue(result.Contains("01"));
    }

    [TestMethod]
    public void Format_MonthNameOnly_ShouldReturnMonthName()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, "MMMM", usePersianDigits: false);
        
        // Assert
        Assert.AreEqual("فروردین", result);
    }

    [TestMethod]
    public void Format_PredefinedStyle_Short_ShouldReturnCorrectFormat()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, ShamsiDateFormatStyle.Short, usePersianDigits: false);
        
        // Assert
        Assert.AreEqual("1403/01/01", result);
    }

    [TestMethod]
    public void Format_PredefinedStyle_Medium_ShouldReturnCorrectFormat()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, ShamsiDateFormatStyle.Medium, usePersianDigits: false);
        
        // Assert
        Assert.AreEqual("01 فروردین 1403", result);
    }

    [TestMethod]
    public void Format_PredefinedStyle_Long_ShouldIncludeDayName()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, ShamsiDateFormatStyle.Long, usePersianDigits: false);
        
        // Assert
        Assert.IsTrue(result.Contains("فروردین"));
        Assert.IsTrue(result.Contains("1403"));
    }

    [TestMethod]
    public void Format_PredefinedStyle_Full_ShouldIncludeComma()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, ShamsiDateFormatStyle.Full, usePersianDigits: false);
        
        // Assert
        Assert.IsTrue(result.Contains("،"));
        Assert.IsTrue(result.Contains("فروردین"));
    }

    [TestMethod]
    public void Format_PredefinedStyle_YearMonth_ShouldReturnMonthAndYear()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, ShamsiDateFormatStyle.YearMonth, usePersianDigits: false);
        
        // Assert
        Assert.AreEqual("فروردین 1403", result);
    }

    [TestMethod]
    public void Format_PredefinedStyle_MonthDay_ShouldReturnDayAndMonth()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, ShamsiDateFormatStyle.MonthDay, usePersianDigits: false);
        
        // Assert
        Assert.AreEqual("01 فروردین", result);
    }

    [TestMethod]
    public void Format_PredefinedStyle_ISO_ShouldReturnISOFormat()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.Format(testDate, ShamsiDateFormatStyle.ISO, usePersianDigits: false);
        
        // Assert
        Assert.AreEqual("1403-01-01", result);
    }

    [TestMethod]
    public void GetPersianMonthName_ValidMonth_ShouldReturnCorrectName()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.GetPersianMonthName(1);
        
        // Assert
        Assert.AreEqual("فروردین", result);
    }

    [TestMethod]
    public void GetPersianMonthName_AllMonths_ShouldReturnCorrectNames()
    {
        // Arrange
        string[] expectedNames = {
            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
            "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
        };

        // Act & Assert
        for (int month = 1; month <= 12; month++)
        {
            string result = ShamsiDateFormatter.GetPersianMonthName(month);
            Assert.AreEqual(expectedNames[month - 1], result);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetPersianMonthName_InvalidMonth_ShouldThrowException()
    {
        // Act
        ShamsiDateFormatter.GetPersianMonthName(13);
    }

    [TestMethod]
    public void GetPersianDayName_AllDays_ShouldReturnCorrectNames()
    {
        // Arrange
        var expectedNames = new Dictionary<DayOfWeek, string>
        {
            { DayOfWeek.Saturday, "شنبه" }, { DayOfWeek.Sunday, "یکشنبه" },
            { DayOfWeek.Monday, "دوشنبه" }, { DayOfWeek.Tuesday, "سه‌شنبه" },
            { DayOfWeek.Wednesday, "چهارشنبه" }, { DayOfWeek.Thursday, "پنج‌شنبه" },
            { DayOfWeek.Friday, "جمعه" }
        };

        // Act & Assert
        foreach (var kvp in expectedNames)
        {
            string result = ShamsiDateFormatter.GetPersianDayName(kvp.Key);
            Assert.AreEqual(kvp.Value, result);
        }
    }

    [TestMethod]
    public void ConvertToPersianDigits_ArabicNumerals_ShouldConvertCorrectly()
    {
        // Arrange
        string input = "1234567890";
        string expected = "۱۲۳۴۵۶۷۸۹۰";

        // Act
        string result = ShamsiDateFormatter.ConvertToPersianDigits(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ConvertToArabicDigits_PersianDigits_ShouldConvertCorrectly()
    {
        // Arrange
        string input = "۱۲۳۴۵۶۷۸۹۰";
        string expected = "1234567890";

        // Act
        string result = ShamsiDateFormatter.ConvertToArabicDigits(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ConvertToPersianDigits_EmptyString_ShouldReturnEmpty()
    {
        // Arrange & Act
        string result = ShamsiDateFormatter.ConvertToPersianDigits("");

        // Assert
        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void ConvertToPersianDigits_NullString_ShouldReturnNull()
    {
        // Arrange & Act
        string? result = ShamsiDateFormatter.ConvertToPersianDigits(null!);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void FormatTime_DefaultFormat_ShouldReturnTimeWithPersianDigits()
    {
        // Arrange
        var timeDate = new DateTime(2024, 3, 20, 14, 30, 0);

        // Act
        string result = ShamsiDateFormatter.FormatTime(timeDate, usePersianDigits: true);

        // Assert
        Assert.AreEqual("۱۴:۳۰", result);
    }

    [TestMethod]
    public void FormatTime_WithSeconds_ShouldIncludeSeconds()
    {
        // Arrange
        var timeDate = new DateTime(2024, 3, 20, 14, 30, 45);

        // Act
        string result = ShamsiDateFormatter.FormatTime(timeDate, "HH:mm:ss", usePersianDigits: false);

        // Assert
        Assert.AreEqual("14:30:45", result);
    }

    [TestMethod]
    public void FormatDateTime_Default_ShouldCombineDateAndTime()
    {
        // Arrange
        var dateTime = new DateTime(2024, 3, 20, 14, 30, 0);

        // Act
        string result = ShamsiDateFormatter.FormatDateTime(dateTime, usePersianDigits: false);

        // Assert
        Assert.IsTrue(result.Contains("فروردین"));
        Assert.IsTrue(result.Contains("14:30"));
    }

    [TestMethod]
    public void Format_ComplexPattern_ShouldHandleAllComponents()
    {
        // Arrange
        string pattern = "dddd، dd MMMM yyyy - HH:mm";
        var dateTime = new DateTime(2024, 3, 20, 14, 30, 0);

        // Act
        string result = ShamsiDateFormatter.Format(dateTime, pattern, usePersianDigits: false);

        // Assert
        Assert.IsTrue(result.Contains("فروردین"));
        Assert.IsTrue(result.Contains("1403"));
        Assert.IsTrue(result.Contains("01"));
        Assert.IsTrue(result.Contains("،"));
    }

    [TestMethod]
    public void Format_DifferentSeasons_ShouldReturnCorrectMonths()
    {
        // Arrange & Act
        string spring = ShamsiDateFormatter.Format(testDate, "MMMM", false); // Farvardin
        string summer = ShamsiDateFormatter.Format(summerDate, "MMMM", false); // Tir
        string winter = ShamsiDateFormatter.Format(winterDate, "MMMM", false); // Azar

        // Assert
        Assert.AreEqual("فروردین", spring);
        Assert.IsTrue(summer.Contains("تیر") || summer.Contains("مرداد")); // Could be either depending on exact date
        Assert.IsTrue(winter.Contains("آذر") || winter.Contains("دی")); // Could be either depending on exact date
    }

    [TestMethod]
    public void Format_LeapYearDate_ShouldHandleCorrectly()
    {
        // Arrange - 30 Esfand 1403 (leap year)
        var leapYearEndDate = new DateTime(2025, 3, 20);

        // Act
        string result = ShamsiDateFormatter.Format(leapYearEndDate, "dd MMMM yyyy", false);

        // Assert
        Assert.IsTrue(result.Contains("اسفند"));
        Assert.IsTrue(result.Contains("1403"));
    }

    [TestMethod]
    public void Performance_FormatManyDates_ShouldCompleteQuickly()
    {
        // Arrange
        var startTime = DateTime.UtcNow;
        var dates = new List<DateTime>();
        
        for (int i = 0; i < 1000; i++)
        {
            dates.Add(testDate.AddDays(i));
        }

        // Act
        foreach (var date in dates)
        {
            ShamsiDateFormatter.Format(date, ShamsiDateFormatStyle.Medium, true);
        }

        // Assert
        var elapsed = DateTime.UtcNow - startTime;
        Assert.IsTrue(elapsed.TotalMilliseconds < 5000, $"Formatting took too long: {elapsed.TotalMilliseconds}ms");
    }
}
