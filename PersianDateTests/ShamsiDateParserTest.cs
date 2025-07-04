using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PersianDate;

namespace PersianDateTests;

[TestClass]
public class ShamsiDateParserTest
{
    [TestMethod]
    public void Parse_ValidNumericFormat_ShouldParseCorrectly()
    {
        // Arrange
        string input = "1403/01/15";

        // Act
        DateTime result = ShamsiDateParser.Parse(input);

        // Assert
        var pc = new System.Globalization.PersianCalendar();
        Assert.AreEqual(1403, pc.GetYear(result));
        Assert.AreEqual(1, pc.GetMonth(result));
        Assert.AreEqual(15, pc.GetDayOfMonth(result));
    }

    [TestMethod]
    public void Parse_ValidTextualFormat_ShouldParseCorrectly()
    {
        // Arrange
        string input = "15 فروردین 1403";

        // Act
        DateTime result = ShamsiDateParser.Parse(input);

        // Assert
        var pc = new System.Globalization.PersianCalendar();
        Assert.AreEqual(1403, pc.GetYear(result));
        Assert.AreEqual(1, pc.GetMonth(result));
        Assert.AreEqual(15, pc.GetDayOfMonth(result));
    }

    [TestMethod]
    public void Parse_PersianDigits_ShouldParseCorrectly()
    {
        // Arrange
        string input = "۱۴۰۳/۰۱/۱۵";

        // Act
        DateTime result = ShamsiDateParser.Parse(input);

        // Assert
        var pc = new System.Globalization.PersianCalendar();
        Assert.AreEqual(1403, pc.GetYear(result));
        Assert.AreEqual(1, pc.GetMonth(result));
        Assert.AreEqual(15, pc.GetDayOfMonth(result));
    }

    [TestMethod]
    public void Parse_ISOFormat_ShouldParseCorrectly()
    {
        // Arrange
        string input = "1403-01-15";

        // Act
        DateTime result = ShamsiDateParser.Parse(input);

        // Assert
        var pc = new System.Globalization.PersianCalendar();
        Assert.AreEqual(1403, pc.GetYear(result));
        Assert.AreEqual(1, pc.GetMonth(result));
        Assert.AreEqual(15, pc.GetDayOfMonth(result));
    }

    [TestMethod]
    public void Parse_DotSeparator_ShouldParseCorrectly()
    {
        // Arrange
        string input = "1403.01.15";

        // Act
        DateTime result = ShamsiDateParser.Parse(input);

        // Assert
        var pc = new System.Globalization.PersianCalendar();
        Assert.AreEqual(1403, pc.GetYear(result));
        Assert.AreEqual(1, pc.GetMonth(result));
        Assert.AreEqual(15, pc.GetDayOfMonth(result));
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Parse_InvalidFormat_ShouldThrowException()
    {
        // Act
        ShamsiDateParser.Parse("invalid date");
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Parse_EmptyString_ShouldThrowException()
    {
        // Act
        ShamsiDateParser.Parse("");
    }

    [TestMethod]
    public void TryParse_ValidDate_ShouldReturnTrue()
    {
        // Arrange
        string input = "1403/01/15";

        // Act
        bool success = ShamsiDateParser.TryParse(input, out DateTime result);

        // Assert
        Assert.IsTrue(success);
        var pc = new System.Globalization.PersianCalendar();
        Assert.AreEqual(1403, pc.GetYear(result));
    }

    [TestMethod]
    public void TryParse_InvalidDate_ShouldReturnFalse()
    {
        // Arrange
        string input = "invalid date";

        // Act
        bool success = ShamsiDateParser.TryParse(input, out DateTime result);

        // Assert
        Assert.IsFalse(success);
        Assert.AreEqual(default(DateTime), result);
    }

    [TestMethod]
    public void TryParse_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool success = ShamsiDateParser.TryParse(input, out DateTime result);

        // Assert
        Assert.IsFalse(success);
    }

    [TestMethod]
    public void TryParse_NullString_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool success = ShamsiDateParser.TryParse(input!, out DateTime result);

        // Assert
        Assert.IsFalse(success);
    }

    [TestMethod]
    public void IsValidShamsiDate_ValidDate_ShouldReturnTrue()
    {
        // Act
        bool result = ShamsiDateParser.IsValidShamsiDate(1403, 1, 15);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValidShamsiDate_InvalidMonth_ShouldReturnFalse()
    {
        // Act
        bool result = ShamsiDateParser.IsValidShamsiDate(1403, 13, 15);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidShamsiDate_InvalidDay_ShouldReturnFalse()
    {
        // Act
        bool result = ShamsiDateParser.IsValidShamsiDate(1403, 1, 32);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidShamsiDate_LeapYearEsfand30_ShouldReturnTrue()
    {
        // Act
        bool result = ShamsiDateParser.IsValidShamsiDate(1403, 12, 30); // 1403 is leap year

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValidShamsiDate_NonLeapYearEsfand30_ShouldReturnFalse()
    {
        // Act
        bool result = ShamsiDateParser.IsValidShamsiDate(1402, 12, 30); // 1402 is not leap year

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void GetDaysInShamsiMonth_Farvardin_ShouldReturn31()
    {
        // Act
        int result = ShamsiDateParser.GetDaysInShamsiMonth(1403, 1);

        // Assert
        Assert.AreEqual(31, result);
    }

    [TestMethod]
    public void GetDaysInShamsiMonth_EsfandLeapYear_ShouldReturn30()
    {
        // Act
        int result = ShamsiDateParser.GetDaysInShamsiMonth(1403, 12); // 1403 is leap year

        // Assert
        Assert.AreEqual(30, result);
    }

    [TestMethod]
    public void GetDaysInShamsiMonth_EsfandNonLeapYear_ShouldReturn29()
    {
        // Act
        int result = ShamsiDateParser.GetDaysInShamsiMonth(1402, 12); // 1402 is not leap year

        // Assert
        Assert.AreEqual(29, result);
    }

    [TestMethod]
    public void ParseAndValidate_ValidDate_ShouldReturnValidResult()
    {
        // Arrange
        string input = "1403/01/15";

        // Act
        var result = ShamsiDateParser.ParseAndValidate(input);

        // Assert
        Assert.IsTrue(result.IsValid);
        Assert.IsTrue(result.ParsedDate.HasValue);
        Assert.AreEqual(input, result.Input);
        Assert.IsTrue(string.IsNullOrEmpty(result.ErrorMessage));
    }

    [TestMethod]
    public void ParseAndValidate_InvalidDate_ShouldReturnInvalidResult()
    {
        // Arrange
        string input = "invalid date";

        // Act
        var result = ShamsiDateParser.ParseAndValidate(input);

        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsFalse(result.ParsedDate.HasValue);
        Assert.AreEqual(input, result.Input);
        Assert.IsFalse(string.IsNullOrEmpty(result.ErrorMessage));
    }

    [TestMethod]
    public void ParseAndValidate_EmptyInput_ShouldReturnInvalidResult()
    {
        // Arrange
        string input = "";

        // Act
        var result = ShamsiDateParser.ParseAndValidate(input);

        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsFalse(result.ParsedDate.HasValue);
        Assert.AreEqual("Input cannot be null or empty.", result.ErrorMessage);
    }

    [TestMethod]
    public void ToShamsiComponents_ValidDate_ShouldReturnCorrectComponents()
    {
        // Arrange
        var gregorianDate = new DateTime(2024, 3, 20); // 1 Farvardin 1403

        // Act
        var result = ShamsiDateParser.ToShamsiComponents(gregorianDate);

        // Assert
        Assert.AreEqual(1403, result.Year);
        Assert.AreEqual(1, result.Month);
        Assert.AreEqual(1, result.Day);
        Assert.IsTrue(result.IsLeapYear);
    }

    [TestMethod]
    public void Parse_AllMonthNames_ShouldParseCorrectly()
    {
        // Arrange
        var monthNames = new[]
        {
            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
            "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
        };

        // Act & Assert
        for (int i = 0; i < monthNames.Length; i++)
        {
            string input = $"15 {monthNames[i]} 1403";
            bool success = ShamsiDateParser.TryParse(input, out DateTime result);
            
            Assert.IsTrue(success, $"Failed to parse month: {monthNames[i]}");
            
            var pc = new System.Globalization.PersianCalendar();
            Assert.AreEqual(i + 1, pc.GetMonth(result));
        }
    }

    [TestMethod]
    public void Parse_DifferentFormats_ShouldAllWork()
    {
        // Arrange
        var formats = new[]
        {
            "1403/01/15",
            "1403-01-15",
            "1403.01.15",
            "15 فروردین 1403",
            "۱۴۰۳/۰۱/۱۵"
        };

        // Act & Assert
        foreach (var format in formats)
        {
            bool success = ShamsiDateParser.TryParse(format, out DateTime result);
            Assert.IsTrue(success, $"Failed to parse format: {format}");
            
            var pc = new System.Globalization.PersianCalendar();
            Assert.AreEqual(1403, pc.GetYear(result));
            Assert.AreEqual(1, pc.GetMonth(result));
            Assert.AreEqual(15, pc.GetDayOfMonth(result));
        }
    }

    [TestMethod]
    public void Parse_EdgeCases_ShouldHandleCorrectly()
    {
        // Arrange & Act & Assert
        
        // First day of year
        bool success1 = ShamsiDateParser.TryParse("1403/01/01", out DateTime result1);
        Assert.IsTrue(success1);
        
        // Last day of leap year
        bool success2 = ShamsiDateParser.TryParse("1403/12/30", out DateTime result2);
        Assert.IsTrue(success2);
        
        // Last day of non-leap year
        bool success3 = ShamsiDateParser.TryParse("1402/12/29", out DateTime result3);
        Assert.IsTrue(success3);
        
        // Invalid leap year day
        bool success4 = ShamsiDateParser.TryParse("1402/12/30", out DateTime result4);
        Assert.IsFalse(success4);
    }

    [TestMethod]
    public void ParseAndValidate_StrictMode_ShouldValidateCorrectly()
    {
        // Arrange & Act
        var validResult = ShamsiDateParser.ParseAndValidate("1403/01/15", strictValidation: true);
        var invalidResult = ShamsiDateParser.ParseAndValidate("1402/12/30", strictValidation: true);

        // Assert
        Assert.IsTrue(validResult.IsValid);
        Assert.IsFalse(invalidResult.IsValid);
    }

    [TestMethod]
    public void Performance_ParseManyDates_ShouldCompleteQuickly()
    {
        // Arrange
        var startTime = DateTime.UtcNow;
        var dateStrings = new List<string>();
        
        for (int i = 1; i <= 1000; i++)
        {
            dateStrings.Add($"1403/01/{i % 29 + 1:00}");
        }

        // Act
        foreach (var dateStr in dateStrings)
        {
            ShamsiDateParser.TryParse(dateStr, out _);
        }

        // Assert
        var elapsed = DateTime.UtcNow - startTime;
        Assert.IsTrue(elapsed.TotalMilliseconds < 5000, $"Parsing took too long: {elapsed.TotalMilliseconds}ms");
    }

    [TestMethod]
    public void Parse_WhitespaceVariations_ShouldHandleCorrectly()
    {
        // Arrange
        var inputs = new[]
        {
            "1403/01/15",
            " 1403/01/15 ",
            "1403 / 01 / 15",
            "15  فروردین  1403",
            " 15 فروردین 1403 "
        };

        // Act & Assert
        foreach (var input in inputs)
        {
            bool success = ShamsiDateParser.TryParse(input, out DateTime result);
            Assert.IsTrue(success, $"Failed to parse: '{input}'");
        }
    }
}
