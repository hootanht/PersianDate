using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDate;

namespace PersianDateTests;

/// <summary>
/// Unit tests for the <see cref="ShamsiCalendarExtensions"/> class.
/// </summary>
[TestClass]
public class ShamsiCalendarExtensionsTest
{
    #region DateTime Extension Tests

    /// <summary>
    /// Tests IsShamsiLeapYear extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void IsShamsiLeapYear_DateTime_WithLeapYear_ShouldReturnTrue()
    {
        // Arrange
        DateTime leapYearDate = new DateTime(2024, 3, 20); // 1403 is a leap year

        // Act
        bool isLeap = leapYearDate.IsShamsiLeapYear();

        // Assert
        Assert.IsTrue(isLeap, "1403 should be a leap year.");
    }

    /// <summary>
    /// Tests IsShamsiLeapYear extension method for DateTime with non-leap year.
    /// </summary>
    [TestMethod]
    public void IsShamsiLeapYear_DateTime_WithNonLeapYear_ShouldReturnFalse()
    {
        // Arrange
        DateTime nonLeapYearDate = new DateTime(2023, 3, 21); // 1402 is not a leap year

        // Act
        bool isLeap = nonLeapYearDate.IsShamsiLeapYear();

        // Assert
        Assert.IsFalse(isLeap, "1402 should not be a leap year.");
    }

    /// <summary>
    /// Tests GetShamsiDaysInMonth extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetShamsiDaysInMonth_DateTime_Farvardin_ShouldReturn31()
    {
        // Arrange
        DateTime farvardinDate = new DateTime(2023, 3, 25); // Farvardin 1402

        // Act
        int days = farvardinDate.GetShamsiDaysInMonth();

        // Assert
        Assert.AreEqual(31, days, "Farvardin should have 31 days.");
    }

    /// <summary>
    /// Tests GetShamsiDaysInMonth extension method for Esfand in leap year.
    /// </summary>
    [TestMethod]
    public void GetShamsiDaysInMonth_DateTime_EsfandLeapYear_ShouldReturn30()
    {
        // Arrange
        DateTime esfandDate = new DateTime(2025, 3, 10); // Esfand 1403 (leap year)

        // Act
        int days = esfandDate.GetShamsiDaysInMonth();

        // Assert
        Assert.AreEqual(30, days, "Esfand in leap year should have 30 days.");
    }

    /// <summary>
    /// Tests GetShamsiDaysInYear extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetShamsiDaysInYear_DateTime_LeapYear_ShouldReturn366()
    {
        // Arrange
        DateTime leapYearDate = new DateTime(2024, 6, 15); // Any date in 1403 (leap year)

        // Act
        int days = leapYearDate.GetShamsiDaysInYear();

        // Assert
        Assert.AreEqual(366, days, "Leap year should have 366 days.");
    }

    /// <summary>
    /// Tests GetShamsiDaysInYear extension method for non-leap year.
    /// </summary>
    [TestMethod]
    public void GetShamsiDaysInYear_DateTime_NonLeapYear_ShouldReturn365()
    {
        // Arrange
        DateTime nonLeapYearDate = new DateTime(2023, 6, 15); // Any date in 1402 (non-leap year)

        // Act
        int days = nonLeapYearDate.GetShamsiDaysInYear();

        // Assert
        Assert.AreEqual(365, days, "Non-leap year should have 365 days.");
    }

    /// <summary>
    /// Tests GetShamsiNewYearDate extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetShamsiNewYearDate_DateTime_ShouldReturnNowruz()
    {
        // Arrange
        DateTime someDate = new DateTime(2023, 8, 15); // Any date in 1402
        DateTime expectedNowruz = new DateTime(2023, 3, 21); // 1 Farvardin 1402

        // Act
        DateTime nowruz = someDate.GetShamsiNewYearDate();

        // Assert
        Assert.AreEqual(expectedNowruz.Date, nowruz.Date, "Should return Nowruz date for the year.");
    }

    /// <summary>
    /// Tests GetShamsiFirstDayOfMonth extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetShamsiFirstDayOfMonth_DateTime_ShouldReturnFirstDay()
    {
        // Arrange
        DateTime midMonthDate = new DateTime(2023, 4, 15); // Mid-Ordibehesht 1402

        // Act
        DateTime firstDay = midMonthDate.GetShamsiFirstDayOfMonth();

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int dayOfMonth = persianCalendar.GetDayOfMonth(firstDay);
        Assert.AreEqual(1, dayOfMonth, "Should return first day of the month.");
    }

    /// <summary>
    /// Tests GetShamsiLastDayOfMonth extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetShamsiLastDayOfMonth_DateTime_ShouldReturnLastDay()
    {
        // Arrange
        DateTime midMonthDate = new DateTime(2023, 3, 25); // Mid-Farvardin 1402

        // Act
        DateTime lastDay = midMonthDate.GetShamsiLastDayOfMonth();

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int dayOfMonth = persianCalendar.GetDayOfMonth(lastDay);
        Assert.AreEqual(31, dayOfMonth, "Should return last day of Farvardin (31st).");
    }

    /// <summary>
    /// Tests GetShamsiDatesInMonth extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetShamsiDatesInMonth_DateTime_ShouldReturnAllDatesInMonth()
    {
        // Arrange
        DateTime farvardinDate = new DateTime(2023, 3, 25); // Farvardin 1402

        // Act
        List<DateTime> dates = farvardinDate.GetShamsiDatesInMonth();

        // Assert
        Assert.AreEqual(31, dates.Count, "Farvardin should have 31 dates.");

        // Verify dates are consecutive
        for (int i = 1; i < dates.Count; i++)
        {
            Assert.AreEqual(1, (dates[i] - dates[i - 1]).Days, "Dates should be consecutive.");
        }
    }

    /// <summary>
    /// Tests GetShamsiDatesInYear extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetShamsiDatesInYear_DateTime_NonLeapYear_ShouldReturn365Dates()
    {
        // Arrange
        DateTime nonLeapYearDate = new DateTime(2023, 6, 15); // Any date in 1402

        // Act
        List<DateTime> dates = nonLeapYearDate.GetShamsiDatesInYear();

        // Assert
        Assert.AreEqual(365, dates.Count, "Non-leap year should have 365 dates.");
    }

    /// <summary>
    /// Tests AddShamsiMonths extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void AddShamsiMonths_DateTime_ShouldAddCorrectly()
    {
        // Arrange
        DateTime baseDate = new DateTime(2023, 3, 21); // 1 Farvardin 1402

        // Act
        DateTime result = baseDate.AddShamsiMonths(3);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultMonth = persianCalendar.GetMonth(result);
        Assert.AreEqual(4, resultMonth, "Should be 4th month (Tir) after adding 3 months.");
    }

    /// <summary>
    /// Tests AddShamsiYears extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void AddShamsiYears_DateTime_ShouldAddCorrectly()
    {
        // Arrange
        DateTime baseDate = new DateTime(2023, 3, 21); // 1 Farvardin 1402

        // Act
        DateTime result = baseDate.AddShamsiYears(2);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultYear = persianCalendar.GetYear(result);
        Assert.AreEqual(1404, resultYear, "Should be year 1404 after adding 2 years.");
    }

    /// <summary>
    /// Tests GetShamsiSeason extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetShamsiSeason_DateTime_Spring_ShouldReturnSpring()
    {
        // Arrange
        DateTime springDate = new DateTime(2023, 3, 21); // 1 Farvardin (Spring)

        // Act
        string season = springDate.GetShamsiSeason();

        // Assert
        Assert.AreEqual("بهار", season, "Farvardin should be in spring.");
    }

    /// <summary>
    /// Tests GetShamsiWeekOfYear extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetShamsiWeekOfYear_DateTime_FirstWeek_ShouldReturnOne()
    {
        // Arrange
        DateTime nowruz = new DateTime(2023, 3, 21); // 1 Farvardin 1402

        // Act
        int week = nowruz.GetShamsiWeekOfYear();

        // Assert
        Assert.AreEqual(1, week, "First day of year should be in week 1.");
    }

    /// <summary>
    /// Tests GetDaysUntil extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetDaysUntil_DateTime_ShouldReturnCorrectDifference()
    {
        // Arrange
        DateTime startDate = new DateTime(2023, 3, 21);
        DateTime endDate = new DateTime(2023, 3, 28);

        // Act
        int days = startDate.GetDaysUntil(endDate);

        // Assert
        Assert.AreEqual(7, days, "Should return 7 days difference.");
    }

    /// <summary>
    /// Tests GetDateRangeUntil extension method for DateTime.
    /// </summary>
    [TestMethod]
    public void GetDateRangeUntil_DateTime_ShouldReturnCorrectRange()
    {
        // Arrange
        DateTime startDate = new DateTime(2023, 3, 21);
        DateTime endDate = new DateTime(2023, 3, 25);

        // Act
        List<DateTime> dates = startDate.GetDateRangeUntil(endDate);

        // Assert
        Assert.AreEqual(5, dates.Count, "Should return 5 dates including start and end.");
        Assert.AreEqual(startDate.Date, dates.First().Date, "First date should match start date.");
        Assert.AreEqual(endDate.Date, dates.Last().Date, "Last date should match end date.");
    }

    /// <summary>
    /// Tests GetDateRangeUntil extension method with invalid range.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetDateRangeUntil_DateTime_StartAfterEnd_ShouldThrowException()
    {
        // Arrange
        DateTime startDate = new DateTime(2023, 3, 25);
        DateTime endDate = new DateTime(2023, 3, 21);

        // Act
        startDate.GetDateRangeUntil(endDate);
    }

    #endregion

    #region DateTimeOffset Extension Tests

    /// <summary>
    /// Tests IsShamsiLeapYear extension method for DateTimeOffset.
    /// </summary>
    [TestMethod]
    public void IsShamsiLeapYear_DateTimeOffset_WithLeapYear_ShouldReturnTrue()
    {
        // Arrange
        DateTimeOffset leapYearDate = new DateTimeOffset(2024, 3, 20, 0, 0, 0, TimeSpan.Zero); // 1403 is a leap year

        // Act
        bool isLeap = leapYearDate.IsShamsiLeapYear();

        // Assert
        Assert.IsTrue(isLeap, "1403 should be a leap year.");
    }

    /// <summary>
    /// Tests GetShamsiDaysInMonth extension method for DateTimeOffset.
    /// </summary>
    [TestMethod]
    public void GetShamsiDaysInMonth_DateTimeOffset_Farvardin_ShouldReturn31()
    {
        // Arrange
        DateTimeOffset farvardinDate = new DateTimeOffset(2023, 3, 25, 12, 0, 0, TimeSpan.Zero); // Farvardin 1402

        // Act
        int days = farvardinDate.GetShamsiDaysInMonth();

        // Assert
        Assert.AreEqual(31, days, "Farvardin should have 31 days.");
    }

    /// <summary>
    /// Tests GetShamsiDaysInYear extension method for DateTimeOffset.
    /// </summary>
    [TestMethod]
    public void GetShamsiDaysInYear_DateTimeOffset_LeapYear_ShouldReturn366()
    {
        // Arrange
        DateTimeOffset leapYearDate = new DateTimeOffset(2024, 6, 15, 12, 0, 0, TimeSpan.Zero); // Any date in 1403 (leap year)

        // Act
        int days = leapYearDate.GetShamsiDaysInYear();

        // Assert
        Assert.AreEqual(366, days, "Leap year should have 366 days.");
    }

    /// <summary>
    /// Tests GetShamsiSeason extension method for DateTimeOffset.
    /// </summary>
    [TestMethod]
    public void GetShamsiSeason_DateTimeOffset_Summer_ShouldReturnSummer()
    {
        // Arrange
        DateTimeOffset summerDate = new DateTimeOffset(2023, 7, 15, 12, 0, 0, TimeSpan.Zero); // Tir (Summer)

        // Act
        string season = summerDate.GetShamsiSeason();

        // Assert
        Assert.AreEqual("تابستان", season, "Tir should be in summer.");
    }

    /// <summary>
    /// Tests AddShamsiMonths extension method for DateTimeOffset.
    /// </summary>
    [TestMethod]
    public void AddShamsiMonths_DateTimeOffset_ShouldAddCorrectly()
    {
        // Arrange
        DateTimeOffset baseDate = new DateTimeOffset(2023, 3, 21, 14, 30, 0, TimeSpan.FromHours(3.5)); // 1 Farvardin 1402

        // Act
        DateTimeOffset result = baseDate.AddShamsiMonths(6);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultMonth = persianCalendar.GetMonth(result.DateTime);
        Assert.AreEqual(7, resultMonth, "Should be 7th month (Mehr) after adding 6 months.");
        Assert.AreEqual(TimeSpan.FromHours(3.5), result.Offset, "Offset should be preserved.");
        Assert.AreEqual(14, result.Hour, "Time should be preserved.");
        Assert.AreEqual(30, result.Minute, "Time should be preserved.");
    }

    /// <summary>
    /// Tests AddShamsiYears extension method for DateTimeOffset.
    /// </summary>
    [TestMethod]
    public void AddShamsiYears_DateTimeOffset_ShouldAddCorrectly()
    {
        // Arrange
        DateTimeOffset baseDate = new DateTimeOffset(2023, 3, 21, 10, 15, 30, TimeSpan.FromHours(-5)); // 1 Farvardin 1402

        // Act
        DateTimeOffset result = baseDate.AddShamsiYears(3);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultYear = persianCalendar.GetYear(result.DateTime);
        Assert.AreEqual(1405, resultYear, "Should be year 1405 after adding 3 years.");
        Assert.AreEqual(TimeSpan.FromHours(-5), result.Offset, "Offset should be preserved.");
        Assert.AreEqual(10, result.Hour, "Time should be preserved.");
        Assert.AreEqual(15, result.Minute, "Time should be preserved.");
        Assert.AreEqual(30, result.Second, "Time should be preserved.");
    }

    #endregion

    #region Integration and Edge Case Tests

    /// <summary>
    /// Integration test combining multiple extension methods.
    /// </summary>
    [TestMethod]
    public void IntegrationTest_MultipleExtensions_ShouldWorkTogether()
    {
        // Arrange
        DateTime testDate = new DateTime(2024, 3, 20); // 1403 (leap year)

        // Act
        bool isLeap = testDate.IsShamsiLeapYear();
        int daysInYear = testDate.GetShamsiDaysInYear();
        string season = testDate.GetShamsiSeason();
        DateTime newYearDate = testDate.GetShamsiNewYearDate();
        DateTime nextYear = testDate.AddShamsiYears(1);

        // Assert
        Assert.IsTrue(isLeap, "1403 should be a leap year.");
        Assert.AreEqual(366, daysInYear, "Leap year should have 366 days.");
        Assert.AreEqual("بهار", season, "Date should be in spring.");
        Assert.AreEqual(new DateTime(2024, 3, 20).Date, newYearDate.Date, "Should return correct Nowruz date.");

        var persianCalendar = new System.Globalization.PersianCalendar();
        int nextYearShamsi = persianCalendar.GetYear(nextYear);
        Assert.AreEqual(1404, nextYearShamsi, "Should be year 1404 after adding one year.");
    }    /// <summary>
         /// Tests extension methods with edge case dates.
         /// </summary>
    [TestMethod]
    public void EdgeCaseTest_ExtensionMethods_ShouldHandleEdgeCases()
    {
        // Arrange - Esfand 30 in leap year
        DateTime esfand30 = new DateTime(2025, 3, 20); // 30 Esfand 1403 (leap year)

        // Act
        bool isLeap = esfand30.IsShamsiLeapYear();
        int daysInMonth = esfand30.GetShamsiDaysInMonth();
        DateTime nextYear = esfand30.AddShamsiYears(1); // Should adjust to 29 Esfand

        // Assert
        Assert.IsTrue(isLeap, "1403 should be a leap year.");
        Assert.AreEqual(30, daysInMonth, "Esfand in leap year should have 30 days.");

        var persianCalendar = new System.Globalization.PersianCalendar();
        int adjustedDay = persianCalendar.GetDayOfMonth(nextYear);
        Assert.AreEqual(29, adjustedDay, "Day should be adjusted from 30 to 29 when moving to non-leap year.");
    }

    /// <summary>
    /// Performance test for extension methods.
    /// </summary>
    [TestMethod]
    public void PerformanceTest_ExtensionMethods_ShouldPerformWell()
    {
        // Arrange
        DateTime testDate = new DateTime(2023, 6, 15);
        DateTime startTime = DateTime.Now;

        // Act
        for (int i = 0; i < 1000; i++)
        {
            bool isLeap = testDate.IsShamsiLeapYear();
            int daysInMonth = testDate.GetShamsiDaysInMonth();
            string season = testDate.GetShamsiSeason();
            DateTime newDate = testDate.AddShamsiMonths(i % 12);
        }

        // Assert
        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;
        Assert.IsTrue(duration.TotalSeconds < 2, "1000 operations should complete within 2 seconds.");
    }

    /// <summary>
    /// Tests all seasons with extension method.
    /// </summary>
    [TestMethod]
    public void GetShamsiSeason_AllSeasons_ShouldReturnCorrectSeasons()
    {
        // Arrange
        var seasonDates = new Dictionary<DateTime, string>
        {
            { new DateTime(2023, 3, 21), "بهار" }, // Farvardin - Spring
            { new DateTime(2023, 6, 22), "تابستان" }, // Tir - Summer
            { new DateTime(2023, 9, 23), "پاییز" }, // Mehr - Autumn
            { new DateTime(2023, 12, 22), "زمستان" } // Dey - Winter
        };

        // Act & Assert
        foreach (var kvp in seasonDates)
        {
            string season = kvp.Key.GetShamsiSeason();
            Assert.AreEqual(kvp.Value, season, $"Date {kvp.Key:yyyy-MM-dd} should be in {kvp.Value}.");
        }
    }

    [TestMethod]
    public void ToShamsiFormattedString_WithFormat_ShouldReturnFormattedString()
    {
        // Arrange
        var date = new DateTime(2024, 3, 20); // 1 Farvardin 1403

        // Act
        string result = date.ToShamsiFormattedString("yyyy/MM/dd", usePersianDigits: false);

        // Assert
        Assert.AreEqual("1403/01/01", result);
    }

    [TestMethod]
    public void ToShamsiFormattedString_WithPersianDigits_ShouldReturnPersianDigits()
    {
        // Arrange
        var date = new DateTime(2024, 3, 20); // 1 Farvardin 1403

        // Act
        string result = date.ToShamsiFormattedString("yyyy/MM/dd", usePersianDigits: true);

        // Assert
        Assert.AreEqual("۱۴۰۳/۰۱/۰۱", result);
    }

    [TestMethod]
    public void ToShamsiFormattedString_WithStyle_ShouldReturnFormattedString()
    {
        // Arrange
        var date = new DateTime(2024, 3, 20); // 1 Farvardin 1403

        // Act
        string result = date.ToShamsiFormattedString(ShamsiDateFormatStyle.Medium, usePersianDigits: false);

        // Assert
        Assert.AreEqual("01 فروردین 1403", result);
    }

    [TestMethod]
    public void GetShamsiMonthName_ShouldReturnCorrectMonthName()
    {
        // Arrange
        var date = new DateTime(2024, 3, 20); // 1 Farvardin 1403

        // Act
        string result = date.GetShamsiMonthName();

        // Assert
        Assert.AreEqual("فروردین", result);
    }

    [TestMethod]
    public void GetShamsiDayName_ShouldReturnCorrectDayName()
    {
        // Arrange
        var date = new DateTime(2024, 3, 20); // 1 Farvardin 1403

        // Act
        string result = date.GetShamsiDayName();

        // Assert
        Assert.IsFalse(string.IsNullOrEmpty(result));
        Assert.IsTrue(result.Contains("شنبه") || result.Contains("یکشنبه") || result.Contains("دوشنبه") || 
                     result.Contains("سه‌شنبه") || result.Contains("چهارشنبه") || result.Contains("پنج‌شنبه") || 
                     result.Contains("جمعه"));
    }

    [TestMethod]
    public void DateTimeOffset_ToShamsiFormattedString_ShouldWork()
    {
        // Arrange
        var dateOffset = new DateTimeOffset(2024, 3, 20, 12, 0, 0, TimeSpan.Zero); // 1 Farvardin 1403

        // Act
        string result = dateOffset.ToShamsiFormattedString("yyyy/MM/dd", usePersianDigits: false);

        // Assert
        Assert.AreEqual("1403/01/01", result);
    }

    [TestMethod]
    public void DateTimeOffset_GetShamsiMonthName_ShouldWork()
    {
        // Arrange
        var dateOffset = new DateTimeOffset(2024, 3, 20, 12, 0, 0, TimeSpan.Zero); // 1 Farvardin 1403

        // Act
        string result = dateOffset.GetShamsiMonthName();

        // Assert
        Assert.AreEqual("فروردین", result);
    }

    #endregion
}
