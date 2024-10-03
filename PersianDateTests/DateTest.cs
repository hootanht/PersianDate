using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDate;

namespace PersianDateTests;

[TestClass]
public class DateTest
{
    // My Birthday
    private readonly DateTime? dateTime = new DateTime(1998, 1, 11);
    private readonly PersianDateShamsi persianDateShamsi = new();

    /// <summary>
    /// Tests the GetShamsiYear method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void YearTest()
    {
        // Arrange
        DateTime? testDate = dateTime;

        // Act
        int? result = persianDateShamsi.GetShamsiYear(testDate);

        // Assert
        Assert.AreEqual(1376, result);
    }

    /// <summary>
    /// Tests the GetShortShamsiYear method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void ShortYearTest()
    {
        // Arrange
        DateTime? testDate = dateTime;

        // Act
        string? result = persianDateShamsi.GetShortShamsiYear(testDate);

        // Assert
        Assert.AreEqual("76", result);
    }

    /// <summary>
    /// Tests the GetShamsiYearToString method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void YearStringTest()
    {
        // Arrange
        DateTime? testDate = dateTime;

        // Act
        string? result = persianDateShamsi.GetShamsiYearToString(testDate);

        // Assert
        Assert.AreEqual("1376", result);
    }

    /// <summary>
    /// Tests the GetShamsiMonth method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void MonthTest()
    {
        // Arrange
        DateTime? testDate = dateTime;

        // Act
        int? result = persianDateShamsi.GetShamsiMonth(testDate);

        // Assert
        Assert.AreEqual(10, result);
    }

    /// <summary>
    /// Tests the GetShamsiMonthString method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void MonthStringTest()
    {
        // Arrange
        DateTime testDate = dateTime.Value;

        // Act
        string result = persianDateShamsi.GetShamsiMonthString(testDate);

        // Assert
        Assert.AreEqual("10", result);
    }

    /// <summary>
    /// Tests the GetShamsiMonthName method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void MonthNameTest()
    {
        // Arrange
        DateTime? testDate = dateTime;

        // Act
        string? result = persianDateShamsi.GetShamsiMonthName(testDate);

        // Assert
        Assert.AreEqual("دی", result);
    }

    /// <summary>
    /// Tests the GetShamsiDay method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void DayTest()
    {
        // Arrange
        DateTime? testDate = dateTime;

        // Act
        int? result = persianDateShamsi.GetShamsiDay(testDate);

        // Assert
        Assert.AreEqual(21, result);
    }

    /// <summary>
    /// Tests the GetShamsiDayString method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void DayStringTest()
    {
        // Arrange
        DateTime? testDate = dateTime;

        // Act
        string? result = persianDateShamsi.GetShamsiDayString(testDate);

        // Assert
        Assert.AreEqual("21", result);
    }

    /// <summary>
    /// Tests the GetShamsiDayName method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void DayNameTest()
    {
        // Arrange
        DateTime? testDate = dateTime;

        // Act
        string? result = persianDateShamsi.GetShamsiDayName(testDate);

        // Assert
        Assert.AreEqual("یکشنبه", result);
    }

    /// <summary>
    /// Tests the GetShamsiDayShortName method with a valid DateTime.
    /// </summary>
    [TestMethod]
    public void DayShortNameTest()
    {
        // Arrange
        DateTime? testDate = dateTime;

        // Act
        string? result = persianDateShamsi.GetShamsiDayShortName(testDate);

        // Assert
        Assert.AreEqual("ی", result);
    }

    /// <summary>
    /// Tests the methods with a null DateTime.
    /// </summary>
    [TestMethod]
    public void NullDateTimeTest()
    {
        // Arrange
        DateTime? nullDateTime = null;

        // Act & Assert
        Assert.IsNull(persianDateShamsi.GetShamsiYear(nullDateTime));
        Assert.IsNull(persianDateShamsi.GetShortShamsiYear(nullDateTime));
        Assert.IsNull(persianDateShamsi.GetShamsiYearToString(nullDateTime));
        Assert.IsNull(persianDateShamsi.GetShamsiMonth(nullDateTime));
        Assert.IsNull(persianDateShamsi.GetShamsiMonthNumber(nullDateTime));
        Assert.IsNull(persianDateShamsi.GetShamsiMonthName(nullDateTime));
        Assert.IsNull(persianDateShamsi.GetShamsiDay(nullDateTime));
        Assert.IsNull(persianDateShamsi.GetShamsiDayString(nullDateTime));
        Assert.IsNull(persianDateShamsi.GetShamsiDayName(nullDateTime));
        Assert.IsNull(persianDateShamsi.GetShamsiDayShortName(nullDateTime));
    }

    /// <summary>
    /// Tests the GetShamsiYear method with a DateTimeOffset.
    /// </summary>
    [TestMethod]
    public void DateTimeOffsetTest()
    {
        // Arrange
        DateTimeOffset? dateTimeOffset = new DateTimeOffset(1998, 1, 11, 0, 0, 0, TimeSpan.Zero);

        // Act
        int? result = persianDateShamsi.GetShamsiYear(dateTimeOffset);

        // Assert
        Assert.AreEqual(1376, result);
    }

    /// <summary>
    /// Tests the GetShamsiMonth method with a DateTimeOffset.
    /// </summary>
    [TestMethod]
    public void MonthDateTimeOffsetTest()
    {
        // Arrange
        DateTimeOffset? dateTimeOffset = new DateTimeOffset(1998, 1, 11, 0, 0, 0, TimeSpan.Zero);

        // Act
        int? result = persianDateShamsi.GetShamsiMonth(dateTimeOffset);

        // Assert
        Assert.AreEqual(10, result);
    }

    /// <summary>
    /// Tests the GetShamsiDay method with a DateTimeOffset.
    /// </summary>
    [TestMethod]
    public void DayDateTimeOffsetTest()
    {
        // Arrange
        DateTimeOffset? dateTimeOffset = new DateTimeOffset(1998, 1, 11, 0, 0, 0, TimeSpan.Zero);

        // Act
        int? result = persianDateShamsi.GetShamsiDay(dateTimeOffset);

        // Assert
        Assert.AreEqual(21, result);
    }

    /// <summary>
    /// Tests multiple methods of PersianDateShamsi with various DateTime inputs.
    /// </summary>
    [TestMethod]
    public void ComplexTest()
    {
        // Arrange
        DateTime? validDate = new DateTime(2023, 3, 21);
        DateTime? nullDate = null;
        _ = new DateTime(1800, 1, 1);
        DateTimeOffset? validDateOffset = new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero);

        // Act
        int? validYear = persianDateShamsi.GetShamsiYear(validDate);
        string? validShortYear = persianDateShamsi.GetShortShamsiYear(validDate);
        string? validYearString = persianDateShamsi.GetShamsiYearToString(validDate);
        int? validMonth = persianDateShamsi.GetShamsiMonth(validDate);
        string validMonthString = persianDateShamsi.GetShamsiMonthString(validDate.Value);
        string? validMonthName = persianDateShamsi.GetShamsiMonthName(validDate);
        int? validDay = persianDateShamsi.GetShamsiDay(validDate);
        string? validDayString = persianDateShamsi.GetShamsiDayString(validDate);
        string? validDayName = persianDateShamsi.GetShamsiDayName(validDate);
        string? validDayShortName = persianDateShamsi.GetShamsiDayShortName(validDate);

        int? nullYear = persianDateShamsi.GetShamsiYear(nullDate);
        string? nullShortYear = persianDateShamsi.GetShortShamsiYear(nullDate);
        string? nullYearString = persianDateShamsi.GetShamsiYearToString(nullDate);
        int? nullMonth = persianDateShamsi.GetShamsiMonth(nullDate);
        int? nullMonthNumber = persianDateShamsi.GetShamsiMonthNumber(nullDate);
        string? nullMonthName = persianDateShamsi.GetShamsiMonthName(nullDate);
        int? nullDay = persianDateShamsi.GetShamsiDay(nullDate);
        string? nullDayString = persianDateShamsi.GetShamsiDayString(nullDate);
        string? nullDayName = persianDateShamsi.GetShamsiDayName(nullDate);
        string? nullDayShortName = persianDateShamsi.GetShamsiDayShortName(nullDate);

        int? validYearOffset = persianDateShamsi.GetShamsiYear(validDateOffset);
        int? validMonthOffset = persianDateShamsi.GetShamsiMonth(validDateOffset);
        int? validDayOffset = persianDateShamsi.GetShamsiDay(validDateOffset);

        // Assert
        Assert.AreEqual(1402, validYear);
        Assert.AreEqual("02", validShortYear);
        Assert.AreEqual("1402", validYearString);
        Assert.AreEqual(1, validMonth);
        Assert.AreEqual("01", validMonthString);
        Assert.AreEqual("فروردین", validMonthName);
        Assert.AreEqual(1, validDay);
        Assert.AreEqual("01", validDayString);
        Assert.AreEqual("سه‌شنبه", validDayName);
        Assert.AreEqual("س", validDayShortName);

        Assert.IsNull(nullYear);
        Assert.IsNull(nullShortYear);
        Assert.IsNull(nullYearString);
        Assert.IsNull(nullMonth);
        Assert.IsNull(nullMonthNumber);
        Assert.IsNull(nullMonthName);
        Assert.IsNull(nullDay);
        Assert.IsNull(nullDayString);
        Assert.IsNull(nullDayName);
        Assert.IsNull(nullDayShortName);

        Assert.AreEqual(1402, validYearOffset);
        Assert.AreEqual(1, validMonthOffset);
        Assert.AreEqual(1, validDayOffset);
    }
}
