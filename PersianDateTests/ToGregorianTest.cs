using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDate;

namespace PersianDateTests;

/// <summary>
/// Unit tests for the <see cref="ToGregorian"/> class.
/// </summary>
[TestClass]
public class ToGregorianTest
{
    private readonly ToGregorian toGregorian;

    public ToGregorianTest()
    {
        toGregorian = new ToGregorian();
    }

    /// <summary>
    /// Tests the GetGregorianYear method.
    /// </summary>
    [TestMethod]
    public void GetGregorianYear_ShouldReturnCorrectYear()
    {
        // Arrange
        int shamsiYear = 1402;
        int shamsiMonth = 1;
        int shamsiDay = 1;

        // Act
        int result = toGregorian.GetGregorianYear(shamsiYear, shamsiMonth, shamsiDay);

        // Assert
        Assert.AreEqual(2023, result);
    }

    /// <summary>
    /// Tests the ToGregorianDate method.
    /// </summary>
    [TestMethod]
    public void ToGregorianDate_ShouldReturnCorrectDate()
    {
        // Arrange
        int shamsiYear = 1402;
        int shamsiMonth = 1;
        int shamsiDay = 1;

        // Act
        DateTime result = toGregorian.ToGregorianDate(shamsiYear, shamsiMonth, shamsiDay);

        // Assert
        Assert.AreEqual(new DateTime(2023, 3, 21), result);
    }

    /// <summary>
    /// Tests the GetGregorianMonth method.
    /// </summary>
    [TestMethod]
    public void GetGregorianMonth_ShouldReturnCorrectMonth()
    {
        // Arrange
        int shamsiYear = 1402;
        int shamsiMonth = 1;
        int shamsiDay = 1;

        // Act
        int result = toGregorian.GetGregorianMonth(shamsiYear, shamsiMonth, shamsiDay);

        // Assert
        Assert.AreEqual(3, result);
    }

    /// <summary>
    /// Tests the GetGregorianDay method.
    /// </summary>
    [TestMethod]
    public void GetGregorianDay_ShouldReturnCorrectDay()
    {
        // Arrange
        int shamsiYear = 1402;
        int shamsiMonth = 1;
        int shamsiDay = 1;

        // Act
        int result = toGregorian.GetGregorianDay(shamsiYear, shamsiMonth, shamsiDay);

        // Assert
        Assert.AreEqual(21, result);
    }

    /// <summary>
    /// Tests the GetGregorianDateString method.
    /// </summary>
    [TestMethod]
    public void GetGregorianDateString_ShouldReturnCorrectDateString()
    {
        // Arrange
        int shamsiYear = 1402;
        int shamsiMonth = 1;
        int shamsiDay = 1;

        // Act
        string result = toGregorian.GetGregorianDateString(shamsiYear, shamsiMonth, shamsiDay);

        // Assert
        Assert.AreEqual("2023-03-21", result);
    }

    /// <summary>
    /// Tests the GetGregorianDayName method.
    /// </summary>
    [TestMethod]
    public void GetGregorianDayName_ShouldReturnCorrectDayName()
    {
        // Arrange
        int shamsiYear = 1402;
        int shamsiMonth = 1;
        int shamsiDay = 1;

        // Act
        string result = toGregorian.GetGregorianDayName(shamsiYear, shamsiMonth, shamsiDay);

        // Assert
        Assert.AreEqual("Tuesday", result);
    }

    /// <summary>
    /// Tests the GetDayNameFromPersianCharacter method.
    /// </summary>
    [TestMethod]
    public void GetDayNameFromPersianCharacter_ShouldReturnCorrectDayName()
    {
        // Arrange
        char persianCharacter = 'ی';

        // Act
        string result = toGregorian.GetDayNameFromPersianCharacter(persianCharacter);

        // Assert
        Assert.AreEqual("Sunday", result);
    }

    /// <summary>
    /// Tests the ConvertRangeToGregorian method.
    /// </summary>
    [TestMethod]
    public void ConvertRangeToGregorian_ShouldReturnCorrectDateRange()
    {
        // Arrange
        int startYear = 1402;
        int startMonth = 1;
        int startDay = 1;
        int endYear = 1402;
        int endMonth = 1;
        int endDay = 10;

        // Act
        List<DateTime> result = toGregorian.ConvertRangeToGregorian(startYear, startMonth, startDay, endYear, endMonth, endDay);

        // Assert
        Assert.AreEqual(10, result.Count);
        Assert.AreEqual(new DateTime(2023, 3, 21), result[0]);
        Assert.AreEqual(new DateTime(2023, 3, 30), result[9]);
    }

    /// <summary>
    /// Tests the GetFirstDayOfShamsiMonth method.
    /// </summary>
    [TestMethod]
    public void GetFirstDayOfShamsiMonth_ShouldReturnCorrectFirstDay()
    {
        // Arrange
        int shamsiYear = 1402;
        int shamsiMonth = 1;

        // Act
        DateTime result = toGregorian.GetFirstDayOfShamsiMonth(shamsiYear, shamsiMonth);

        // Assert
        Assert.AreEqual(new DateTime(2023, 3, 21), result);
    }
}
