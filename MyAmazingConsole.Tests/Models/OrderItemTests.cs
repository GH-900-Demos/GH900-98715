using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests.Models;

public class OrderItemTests
{
    [Fact]
    public void Quantity_WhenSetToPositiveValue_ShouldSucceed()
    {
        var item = new OrderItem { Quantity = 5 };
        Assert.Equal(5, item.Quantity);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Quantity_WhenSetToZeroOrNegative_ShouldThrowArgumentOutOfRangeException(int quantity)
    {
        var item = new OrderItem { Quantity = 1 };
        Assert.Throws<ArgumentOutOfRangeException>(() => item.Quantity = quantity);
    }

    [Fact]
    public void TotalCost_ShouldBeProductOfQuantityAndUnitCost()
    {
        var item = new OrderItem { Quantity = 3, UnitCost = 10.00m };
        Assert.Equal(30.00m, item.TotalCost);
    }
}
