using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests.Models;

/// <summary>
/// Unit tests for the <see cref="OrderItem"/> model.
/// Verifies the quantity validation logic and the computed <see cref="OrderItem.TotalCost"/> property.
/// </summary>
public class OrderItemTests
{
    /// <summary>
    /// Verifies that setting <see cref="OrderItem.Quantity"/> to a positive value succeeds.
    /// </summary>
    [Fact]
    public void Quantity_WhenSetToPositiveValue_ShouldSucceed()
    {
        var item = new OrderItem { Quantity = 5 };
        Assert.Equal(5, item.Quantity);
    }

    /// <summary>
    /// Verifies that setting <see cref="OrderItem.Quantity"/> to zero or a negative value
    /// throws an <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <param name="quantity">The invalid quantity value to test.</param>
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Quantity_WhenSetToZeroOrNegative_ShouldThrowArgumentOutOfRangeException(int quantity)
    {
        var item = new OrderItem { Quantity = 1 };
        Assert.Throws<ArgumentOutOfRangeException>(() => item.Quantity = quantity);
    }

    /// <summary>
    /// Verifies that <see cref="OrderItem.TotalCost"/> returns the product of
    /// <see cref="OrderItem.Quantity"/> and <see cref="OrderItem.UnitCost"/>.
    /// </summary>
    [Fact]
    public void TotalCost_ShouldBeProductOfQuantityAndUnitCost()
    {
        var item = new OrderItem { Quantity = 3, UnitCost = 10.00m };
        Assert.Equal(30.00m, item.TotalCost);
    }

    /**
     * This is a sample test method that can be used as a template for future tests.
     * It currently just prints a message to the console, but you can replace it with actual test logic.
     */
    [Fact]
    public void sampleTest()
    {
        Console.WriteLine("Hello from sampleTest");
    }
}
