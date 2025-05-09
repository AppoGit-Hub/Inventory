using FakeItEasy;
using Xunit;

using Inventory.IBusiness;
using Inventory.IDAL;

namespace Inventory.Business.Tests;

public class OrderBLTest
{
    private IOrderBL Logic { get; }

    public OrderBLTest()
    {
        Logic = new OrderBL(
            A.Fake<IOrderRepository>()
        );
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        // Act
        // Assert
    }
}