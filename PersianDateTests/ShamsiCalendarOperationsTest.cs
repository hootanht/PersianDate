using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDate;

namespace PersianDateTests;

/// <summary>
/// Unit tests for the <see cref="ShamsiCalendarOperations"/> class.
/// </summary>
[TestClass]
public class ShamsiCalendarOperationsTest
{
    private readonly ShamsiCalendarOperations calendarOps;

    public ShamsiCalendarOperationsTest()
    {
        calendarOps = new ShamsiCalendarOperations();
    }

    #region IsLeapYear Tests

    /// <summary>
    /// Tests the IsLeapYear method with known leap years.
    /// </summary>
    [TestMethod]
    public void IsLeapYear_WithKnownLeapYears_ShouldReturnTrue()
    {
        // Arrange - Known leap years in Persian calendar (based on actual PersianCalendar)
        int[] leapYears = { 1370, 1375, 1379, 1383, 1387, 1391, 1395, 1399, 1403 };

        // Act & Assert
        foreach (int year in leapYears)
        {
            Assert.IsTrue(calendarOps.IsLeapYear(year), $"Year {year} should be a leap year.");
        }
    }

    /// <summary>
    /// Tests the IsLeapYear method with known non-leap years.
    /// </summary>
    [TestMethod]
    public void IsLeapYear_WithNonLeapYears_ShouldReturnFalse()
    {
        // Arrange - Known non-leap years (based on actual PersianCalendar)
        int[] nonLeapYears = { 1371, 1372, 1373, 1374, 1376, 1377, 1378, 1380, 1381, 1382, 1402 };

        // Act & Assert
        foreach (int year in nonLeapYears)
        {
            Assert.IsFalse(calendarOps.IsLeapYear(year), $"Year {year} should not be a leap year.");
        }
    }

    /// <summary>
    /// Tests the IsLeapYear method with invalid year.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void IsLeapYear_WithInvalidYear_ShouldThrowException()
    {
        // Act
        calendarOps.IsLeapYear(-1);
    }

    #endregion

    #region GetDaysInMonth Tests

    /// <summary>
    /// Tests GetDaysInMonth for first six months (31 days each).
    /// </summary>
    [TestMethod]
    public void GetDaysInMonth_FirstSixMonths_ShouldReturn31()
    {
        // Arrange
        int year = 1402;

        // Act & Assert
        for (int month = 1; month <= 6; month++)
        {
            int days = calendarOps.GetDaysInMonth(year, month);
            Assert.AreEqual(31, days, $"Month {month} should have 31 days.");
        }
    }

    /// <summary>
    /// Tests GetDaysInMonth for months 7-11 (30 days each).
    /// </summary>
    [TestMethod]
    public void GetDaysInMonth_Months7To11_ShouldReturn30()
    {
        // Arrange
        int year = 1402;

        // Act & Assert
        for (int month = 7; month <= 11; month++)
        {
            int days = calendarOps.GetDaysInMonth(year, month);
            Assert.AreEqual(30, days, $"Month {month} should have 30 days.");
        }
    }

    /// <summary>
    /// Tests GetDaysInMonth for Esfand in non-leap year (29 days).
    /// </summary>
    [TestMethod]
    public void GetDaysInMonth_EsfandNonLeapYear_ShouldReturn29()
    {
        // Arrange
        int nonLeapYear = 1402;

        // Act
        int days = calendarOps.GetDaysInMonth(nonLeapYear, 12);

        // Assert
        Assert.AreEqual(29, days, "Esfand in non-leap year should have 29 days.");
    }

    /// <summary>
    /// Tests GetDaysInMonth for Esfand in leap year (30 days).
    /// </summary>
    [TestMethod]
    public void GetDaysInMonth_EsfandLeapYear_ShouldReturn30()
    {
        // Arrange
        int leapYear = 1403;

        // Act
        int days = calendarOps.GetDaysInMonth(leapYear, 12);

        // Assert
        Assert.AreEqual(30, days, "Esfand in leap year should have 30 days.");
    }

    /// <summary>
    /// Tests GetDaysInMonth with invalid month.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetDaysInMonth_WithInvalidMonth_ShouldThrowException()
    {
        // Act
        calendarOps.GetDaysInMonth(1402, 13);
    }

    /// <summary>
    /// Tests GetDaysInMonth with zero month.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetDaysInMonth_WithZeroMonth_ShouldThrowException()
    {
        // Act
        calendarOps.GetDaysInMonth(1402, 0);
    }

    #endregion

    #region GetDaysInYear Tests

    /// <summary>
    /// Tests GetDaysInYear for non-leap year.
    /// </summary>
    [TestMethod]
    public void GetDaysInYear_NonLeapYear_ShouldReturn365()
    {
        // Arrange
        int nonLeapYear = 1402;

        // Act
        int days = calendarOps.GetDaysInYear(nonLeapYear);

        // Assert
        Assert.AreEqual(365, days, "Non-leap year should have 365 days.");
    }

    /// <summary>
    /// Tests GetDaysInYear for leap year.
    /// </summary>
    [TestMethod]
    public void GetDaysInYear_LeapYear_ShouldReturn366()
    {
        // Arrange
        int leapYear = 1403;

        // Act
        int days = calendarOps.GetDaysInYear(leapYear);

        // Assert
        Assert.AreEqual(366, days, "Leap year should have 366 days.");
    }

    #endregion

    #region GetNewYearDate Tests

    /// <summary>
    /// Tests GetNewYearDate for known year.
    /// </summary>
    [TestMethod]
    public void GetNewYearDate_ForKnownYear_ShouldReturnCorrectDate()
    {
        // Arrange
        int shamsiYear = 1402;
        DateTime expectedNowruz = new DateTime(2023, 3, 21); // 1 Farvardin 1402

        // Act
        DateTime actualNowruz = calendarOps.GetNewYearDate(shamsiYear);

        // Assert
        Assert.AreEqual(expectedNowruz.Date, actualNowruz.Date, "Nowruz date should match expected Gregorian date.");
    }

    /// <summary>
    /// Tests GetNewYearDate for multiple years.
    /// </summary>
    [TestMethod]
    public void GetNewYearDate_ForMultipleYears_ShouldReturnCorrectDates()
    {
        // Arrange
        var expectedDates = new Dictionary<int, DateTime>
        {
            { 1401, new DateTime(2022, 3, 21) },
            { 1402, new DateTime(2023, 3, 21) },
            { 1403, new DateTime(2024, 3, 20) },
            { 1404, new DateTime(2025, 3, 21) }
        };

        // Act & Assert
        foreach (var kvp in expectedDates)
        {
            DateTime actualDate = calendarOps.GetNewYearDate(kvp.Key);
            Assert.AreEqual(kvp.Value.Date, actualDate.Date, $"Nowruz for year {kvp.Key} should be {kvp.Value:yyyy-MM-dd}");
        }
    }

    #endregion

    #region GetFirstDayOfMonth and GetLastDayOfMonth Tests

    /// <summary>
    /// Tests GetFirstDayOfMonth.
    /// </summary>
    [TestMethod]
    public void GetFirstDayOfMonth_ShouldReturnCorrectDate()
    {
        // Arrange
        int year = 1402;
        int month = 7; // Mehr
        DateTime expected = new DateTime(2023, 9, 23); // 1 Mehr 1402

        // Act
        DateTime actual = calendarOps.GetFirstDayOfMonth(year, month);

        // Assert
        Assert.AreEqual(expected.Date, actual.Date, "First day of month should match expected date.");
    }

    /// <summary>
    /// Tests GetLastDayOfMonth for normal month.
    /// </summary>
    [TestMethod]
    public void GetLastDayOfMonth_NormalMonth_ShouldReturnCorrectDate()
    {
        // Arrange
        int year = 1402;
        int month = 1; // Farvardin (31 days)

        // Act
        DateTime lastDay = calendarOps.GetLastDayOfMonth(year, month);

        // Assert
        Assert.AreEqual(23, lastDay.Hour, "Time should be set to end of day.");
        Assert.AreEqual(59, lastDay.Minute);
        Assert.AreEqual(59, lastDay.Second);
    }

    /// <summary>
    /// Tests GetLastDayOfMonth for Esfand in leap year.
    /// </summary>
    [TestMethod]
    public void GetLastDayOfMonth_EsfandLeapYear_ShouldReturn30thDay()
    {
        // Arrange
        int leapYear = 1403;
        int month = 12; // Esfand

        // Act
        DateTime lastDay = calendarOps.GetLastDayOfMonth(leapYear, month);

        // Convert back to verify it's the 30th day
        var persianCalendar = new System.Globalization.PersianCalendar();
        int dayOfMonth = persianCalendar.GetDayOfMonth(lastDay);

        // Assert
        Assert.AreEqual(30, dayOfMonth, "Last day of Esfand in leap year should be 30th.");
    }

    #endregion

    #region GetDateRange Tests

    /// <summary>
    /// Tests GetDateRange for single day.
    /// </summary>
    [TestMethod]
    public void GetDateRange_SingleDay_ShouldReturnOneDate()
    {
        // Arrange
        int year = 1402, month = 1, day = 1;

        // Act
        List<DateTime> dates = calendarOps.GetDateRange(year, month, day, year, month, day);

        // Assert
        Assert.AreEqual(1, dates.Count, "Single day range should return one date.");
    }

    /// <summary>
    /// Tests GetDateRange for one week.
    /// </summary>
    [TestMethod]
    public void GetDateRange_OneWeek_ShouldReturnSevenDates()
    {
        // Arrange
        int startYear = 1402, startMonth = 1, startDay = 1;
        int endYear = 1402, endMonth = 1, endDay = 7;

        // Act
        List<DateTime> dates = calendarOps.GetDateRange(startYear, startMonth, startDay, endYear, endMonth, endDay);

        // Assert
        Assert.AreEqual(7, dates.Count, "One week range should return seven dates.");

        // Verify dates are consecutive
        for (int i = 1; i < dates.Count; i++)
        {
            Assert.AreEqual(1, (dates[i] - dates[i - 1]).Days, "Dates should be consecutive.");
        }
    }

    /// <summary>
    /// Tests GetDateRange with invalid range (start after end).
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetDateRange_StartAfterEnd_ShouldThrowException()
    {
        // Act
        calendarOps.GetDateRange(1402, 2, 1, 1402, 1, 1);
    }

    #endregion

    #region GetDatesInMonth Tests

    /// <summary>
    /// Tests GetDatesInMonth for Farvardin.
    /// </summary>
    [TestMethod]
    public void GetDatesInMonth_Farvardin_ShouldReturn31Dates()
    {
        // Arrange
        int year = 1402, month = 1;

        // Act
        List<DateTime> dates = calendarOps.GetDatesInMonth(year, month);

        // Assert
        Assert.AreEqual(31, dates.Count, "Farvardin should have 31 dates.");
    }

    /// <summary>
    /// Tests GetDatesInMonth for Esfand in non-leap year.
    /// </summary>
    [TestMethod]
    public void GetDatesInMonth_EsfandNonLeapYear_ShouldReturn29Dates()
    {
        // Arrange
        int nonLeapYear = 1402, month = 12;

        // Act
        List<DateTime> dates = calendarOps.GetDatesInMonth(nonLeapYear, month);

        // Assert
        Assert.AreEqual(29, dates.Count, "Esfand in non-leap year should have 29 dates.");
    }

    #endregion

    #region GetDatesInYear Tests

    /// <summary>
    /// Tests GetDatesInYear for non-leap year.
    /// </summary>
    [TestMethod]
    public void GetDatesInYear_NonLeapYear_ShouldReturn365Dates()
    {
        // Arrange
        int nonLeapYear = 1402;

        // Act
        List<DateTime> dates = calendarOps.GetDatesInYear(nonLeapYear);

        // Assert
        Assert.AreEqual(365, dates.Count, "Non-leap year should have 365 dates.");
    }

    /// <summary>
    /// Tests GetDatesInYear for leap year.
    /// </summary>
    [TestMethod]
    public void GetDatesInYear_LeapYear_ShouldReturn366Dates()
    {
        // Arrange
        int leapYear = 1403;

        // Act
        List<DateTime> dates = calendarOps.GetDatesInYear(leapYear);

        // Assert
        Assert.AreEqual(366, dates.Count, "Leap year should have 366 dates.");
    }

    #endregion

    #region AddShamsiMonths Tests

    /// <summary>
    /// Tests AddShamsiMonths with positive months.
    /// </summary>
    [TestMethod]
    public void AddShamsiMonths_PositiveMonths_ShouldAddCorrectly()
    {
        // Arrange
        DateTime baseDate = new DateTime(2023, 3, 21); // 1 Farvardin 1402
        int monthsToAdd = 3;

        // Act
        DateTime result = calendarOps.AddShamsiMonths(baseDate, monthsToAdd);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultMonth = persianCalendar.GetMonth(result);
        Assert.AreEqual(4, resultMonth, "Should be 4th month (Tir) after adding 3 months to Farvardin.");
    }

    /// <summary>
    /// Tests AddShamsiMonths with year overflow.
    /// </summary>
    [TestMethod]
    public void AddShamsiMonths_WithYearOverflow_ShouldHandleCorrectly()
    {
        // Arrange
        DateTime baseDate = new DateTime(2023, 12, 22); // Around 1 Dey 1402
        int monthsToAdd = 15; // Should go to next year

        // Act
        DateTime result = calendarOps.AddShamsiMonths(baseDate, monthsToAdd);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultYear = persianCalendar.GetYear(result);
        int resultMonth = persianCalendar.GetMonth(result);
        Assert.IsTrue(resultYear > 1402, "Year should have increased.");
        Assert.IsTrue(resultMonth <= 12, "Month should be valid.");
    }

    /// <summary>
    /// Tests AddShamsiMonths with negative months.
    /// </summary>
    [TestMethod]
    public void AddShamsiMonths_NegativeMonths_ShouldSubtractCorrectly()
    {
        // Arrange
        DateTime baseDate = new DateTime(2023, 6, 22); // Around Tir 1402
        int monthsToSubtract = -3;

        // Act
        DateTime result = calendarOps.AddShamsiMonths(baseDate, monthsToSubtract);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultMonth = persianCalendar.GetMonth(result);
        Assert.AreEqual(1, resultMonth, "Should be 1st month (Farvardin) after subtracting 3 months from Tir.");
    }

    /// <summary>
    /// Tests AddShamsiMonths with day adjustment.
    /// </summary>
    [TestMethod]
    public void AddShamsiMonths_DayAdjustment_ShouldAdjustToValidDay()
    {
        // Arrange - Start with 31st of a month that has 31 days
        DateTime baseDate = new DateTime(2023, 4, 21); // 31 Farvardin 1402
        int monthsToAdd = 6; // Go to Mehr (30 days)

        // Act
        DateTime result = calendarOps.AddShamsiMonths(baseDate, monthsToAdd);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultDay = persianCalendar.GetDayOfMonth(result);
        Assert.IsTrue(resultDay <= 30, "Day should be adjusted to valid day in target month.");
    }

    #endregion

    #region AddShamsiYears Tests

    /// <summary>
    /// Tests AddShamsiYears with positive years.
    /// </summary>
    [TestMethod]
    public void AddShamsiYears_PositiveYears_ShouldAddCorrectly()
    {
        // Arrange
        DateTime baseDate = new DateTime(2023, 3, 21); // 1 Farvardin 1402
        int yearsToAdd = 5;

        // Act
        DateTime result = calendarOps.AddShamsiYears(baseDate, yearsToAdd);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultYear = persianCalendar.GetYear(result);
        Assert.AreEqual(1407, resultYear, "Should be year 1407 after adding 5 years to 1402.");
    }

    /// <summary>
    /// Tests AddShamsiYears with leap year adjustment.
    /// </summary>
    [TestMethod]
    public void AddShamsiYears_LeapYearAdjustment_ShouldAdjustDay()
    {
        // Arrange - Start with 30 Esfand of a leap year
        DateTime leapYearEsfand30 = new DateTime(2024, 3, 19); // 30 Esfand 1403 (leap year)
        int yearsToAdd = 1; // Go to 1404 (non-leap year)

        // Act
        DateTime result = calendarOps.AddShamsiYears(leapYearEsfand30, yearsToAdd);

        // Assert
        var persianCalendar = new System.Globalization.PersianCalendar();
        int resultDay = persianCalendar.GetDayOfMonth(result);
        Assert.AreEqual(29, resultDay, "Day should be adjusted from 30 to 29 when moving from leap to non-leap year.");
    }

    #endregion

    #region GetDaysBetween Tests

    /// <summary>
    /// Tests GetDaysBetween with same date.
    /// </summary>
    [TestMethod]
    public void GetDaysBetween_SameDate_ShouldReturnZero()
    {
        // Arrange
        DateTime date = DateTime.Now;

        // Act
        int days = calendarOps.GetDaysBetween(date, date);

        // Assert
        Assert.AreEqual(0, days, "Same date should return zero days difference.");
    }

    /// <summary>
    /// Tests GetDaysBetween with one week difference.
    /// </summary>
    [TestMethod]
    public void GetDaysBetween_OneWeek_ShouldReturnSeven()
    {
        // Arrange
        DateTime startDate = new DateTime(2023, 3, 21);
        DateTime endDate = startDate.AddDays(7);

        // Act
        int days = calendarOps.GetDaysBetween(startDate, endDate);

        // Assert
        Assert.AreEqual(7, days, "One week difference should return 7 days.");
    }

    /// <summary>
    /// Tests GetDaysBetween with negative result.
    /// </summary>
    [TestMethod]
    public void GetDaysBetween_NegativeResult_ShouldReturnNegative()
    {
        // Arrange
        DateTime startDate = new DateTime(2023, 3, 28);
        DateTime endDate = new DateTime(2023, 3, 21);

        // Act
        int days = calendarOps.GetDaysBetween(startDate, endDate);

        // Assert
        Assert.AreEqual(-7, days, "End date before start date should return negative days.");
    }

    #endregion

    #region GetSeason Tests

    /// <summary>
    /// Tests GetSeason for spring months.
    /// </summary>
    [TestMethod]
    public void GetSeason_SpringMonths_ShouldReturnSpring()
    {
        // Arrange
        DateTime[] springDates = {
            new DateTime(2023, 3, 21), // 1 Farvardin
            new DateTime(2023, 4, 21), // Ordibehesht
            new DateTime(2023, 5, 22)  // Khordad
        };

        // Act & Assert
        foreach (DateTime date in springDates)
        {
            string season = calendarOps.GetSeason(date);
            Assert.AreEqual("بهار", season, $"Date {date:yyyy-MM-dd} should be in spring.");
        }
    }

    /// <summary>
    /// Tests GetSeason for summer months.
    /// </summary>
    [TestMethod]
    public void GetSeason_SummerMonths_ShouldReturnSummer()
    {
        // Arrange
        DateTime[] summerDates = {
            new DateTime(2023, 6, 22), // Tir
            new DateTime(2023, 7, 23), // Mordad
            new DateTime(2023, 8, 23)  // Shahrivar
        };

        // Act & Assert
        foreach (DateTime date in summerDates)
        {
            string season = calendarOps.GetSeason(date);
            Assert.AreEqual("تابستان", season, $"Date {date:yyyy-MM-dd} should be in summer.");
        }
    }

    /// <summary>
    /// Tests GetSeason for autumn months.
    /// </summary>
    [TestMethod]
    public void GetSeason_AutumnMonths_ShouldReturnAutumn()
    {
        // Arrange
        DateTime[] autumnDates = {
            new DateTime(2023, 9, 23), // Mehr
            new DateTime(2023, 10, 23), // Aban
            new DateTime(2023, 11, 22)  // Azar
        };

        // Act & Assert
        foreach (DateTime date in autumnDates)
        {
            string season = calendarOps.GetSeason(date);
            Assert.AreEqual("پاییز", season, $"Date {date:yyyy-MM-dd} should be in autumn.");
        }
    }

    /// <summary>
    /// Tests GetSeason for winter months.
    /// </summary>
    [TestMethod]
    public void GetSeason_WinterMonths_ShouldReturnWinter()
    {
        // Arrange
        DateTime[] winterDates = {
            new DateTime(2023, 12, 22), // Dey
            new DateTime(2024, 1, 21),  // Bahman
            new DateTime(2024, 2, 20)   // Esfand
        };

        // Act & Assert
        foreach (DateTime date in winterDates)
        {
            string season = calendarOps.GetSeason(date);
            Assert.AreEqual("زمستان", season, $"Date {date:yyyy-MM-dd} should be in winter.");
        }
    }

    #endregion

    #region GetWeekOfYear Tests

    /// <summary>
    /// Tests GetWeekOfYear for first day of year.
    /// </summary>
    [TestMethod]
    public void GetWeekOfYear_FirstDayOfYear_ShouldReturnOne()
    {
        // Arrange
        DateTime nowruz = new DateTime(2023, 3, 21); // 1 Farvardin 1402

        // Act
        int week = calendarOps.GetWeekOfYear(nowruz);

        // Assert
        Assert.AreEqual(1, week, "First day of year should be in week 1.");
    }

    /// <summary>
    /// Tests GetWeekOfYear for various dates.
    /// </summary>
    [TestMethod]
    public void GetWeekOfYear_VariousDates_ShouldReturnValidWeeks()
    {
        // Arrange
        DateTime[] testDates = {
            new DateTime(2023, 3, 21), // 1 Farvardin 1402
            new DateTime(2023, 3, 28), // 7 Farvardin 1402 (should be week 2)
            new DateTime(2023, 4, 4),  // Around 14 Farvardin 1402
        };

        // Act & Assert
        foreach (DateTime date in testDates)
        {
            int week = calendarOps.GetWeekOfYear(date);
            Assert.IsTrue(week >= 1 && week <= 53, $"Week number {week} for date {date:yyyy-MM-dd} should be between 1 and 53.");
        }
    }

    #endregion

    #region Integration Tests

    /// <summary>
    /// Integration test combining multiple operations.
    /// </summary>
    [TestMethod]
    public void IntegrationTest_MultipleOperations_ShouldWorkTogether()
    {
        // Arrange
        int testYear = 1403; // Leap year

        // Act
        bool isLeap = calendarOps.IsLeapYear(testYear);
        int daysInYear = calendarOps.GetDaysInYear(testYear);
        int daysInEsfand = calendarOps.GetDaysInMonth(testYear, 12);
        DateTime nowruz = calendarOps.GetNewYearDate(testYear);
        string season = calendarOps.GetSeason(nowruz);

        // Assert
        Assert.IsTrue(isLeap, "1403 should be a leap year.");
        Assert.AreEqual(366, daysInYear, "Leap year should have 366 days.");
        Assert.AreEqual(30, daysInEsfand, "Esfand in leap year should have 30 days.");
        Assert.AreEqual("بهار", season, "Nowruz should be in spring.");
    }

    /// <summary>
    /// Performance test for GetDatesInYear.
    /// </summary>
    [TestMethod]
    public void PerformanceTest_GetDatesInYear_ShouldCompleteQuickly()
    {
        // Arrange
        DateTime startTime = DateTime.Now;
        int testYear = 1403;

        // Act
        List<DateTime> dates = calendarOps.GetDatesInYear(testYear);

        // Assert
        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;

        Assert.AreEqual(366, dates.Count, "Should return all dates in leap year.");
        Assert.IsTrue(duration.TotalSeconds < 1, "Operation should complete within 1 second.");
    }

    #endregion
}
