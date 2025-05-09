using FakeItEasy;
using Xunit;
using Inventory.IDAL;
using Inventory.IBusiness;

namespace Inventory.Business.Tests;

public class SupplierBLTest
{
    private ISupplierBL Logic { get; }

    public SupplierBLTest()
    {
        Logic = new SupplierBL(
            A.Fake<ISupplierRepository>()
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