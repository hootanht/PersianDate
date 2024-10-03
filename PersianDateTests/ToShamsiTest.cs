using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDate;

namespace PersianDateTests;

[TestClass]
public class ToShamsiTest
{
    // My Birthday
    private readonly DateTime? dateTime = new DateTime(1998, 1, 11);
    private readonly DateTimeOffset? dateTimeOffset = new DateTimeOffset(1998, 1, 11, 0, 0, 0, TimeSpan.Zero);

    /// <summary>
    /// Test for converting DateTime to Shamsi date.
    /// </summary>
    [TestMethod]
    public void ToShamsiDateTest()
    {
        // Arrange
        DateTime? testDateTime = dateTime;

        // Act
        string? result = testDateTime.ToShamsiDate();

        // Assert
        Assert.AreEqual("1376/10/21", result);
    }

    /// <summary>
    /// Test for converting DateTime to short Shamsi date.
    /// </summary>
    [TestMethod]
    public void ToShortShamsiDateTest()
    {
        // Arrange
        DateTime? testDateTime = dateTime;

        // Act
        string? result = testDateTime.ToShortShamsiDate();

        // Assert
        Assert.AreEqual("76/10/21", result);
    }

    /// <summary>
    /// Test for converting DateTime to long Shamsi date.
    /// </summary>
    [TestMethod]
    public void ToLongShamsiDateTest()
    {
        // Arrange
        DateTime? testDateTime = dateTime;

        // Act
        string? result = testDateTime.ToLongShamsiDate();

        // Assert
        Assert.AreEqual("یکشنبه 21 دی 1376", result);
    }

    /// <summary>
    /// Test for converting null DateTime to Shamsi date.
    /// </summary>
    [TestMethod]
    public void NullDateTimeTest()
    {
        // Arrange
        DateTime? nullDateTime = null;

        // Act
        string? result = nullDateTime.ToShamsiDate();

        // Assert
        Assert.IsNull(result);
    }

    /// <summary>
    /// Test for converting DateTimeOffset to Shamsi date.
    /// </summary>
    [TestMethod]
    public void ToShamsiDateOffsetTest()
    {
        // Arrange
        DateTimeOffset? testDateTimeOffset = dateTimeOffset;

        // Act
        string? result = testDateTimeOffset.ToShamsiDate();

        // Assert
        Assert.AreEqual("1376/10/21", result);
    }

    /// <summary>
    /// Test for converting DateTimeOffset to short Shamsi date.
    /// </summary>
    [TestMethod]
    public void ToShortShamsiDateOffsetTest()
    {
        // Arrange
        DateTimeOffset? testDateTimeOffset = dateTimeOffset;

        // Act
        string? result = testDateTimeOffset.ToShortShamsiDate();

        // Assert
        Assert.AreEqual("76/10/21", result);
    }

    /// <summary>
    /// Test for converting DateTimeOffset to long Shamsi date.
    /// </summary>
    [TestMethod]
    public void ToLongShamsiDateOffsetTest()
    {
        // Arrange
        DateTimeOffset? testDateTimeOffset = dateTimeOffset;

        // Act
        string? result = testDateTimeOffset.ToLongShamsiDate();

        // Assert
        Assert.AreEqual("یکشنبه 21 دی 1376", result);
    }

    /// <summary>
    /// Test for converting null DateTimeOffset to Shamsi date.
    /// </summary>
    [TestMethod]
    public void NullDateTimeOffsetTest()
    {
        // Arrange
        DateTimeOffset? nullDateTimeOffset = null;

        // Act
        string? result = nullDateTimeOffset.ToShamsiDate();

        // Assert
        Assert.IsNull(result);
    }
}
