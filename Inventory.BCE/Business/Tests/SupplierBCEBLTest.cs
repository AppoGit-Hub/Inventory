using FakeItEasy;
using Inventory.IBusiness.BCE;
using Inventory.IDAL.BCE;
using Xunit;

namespace Inventory.Business.Tests.BCE;

public class SupplierBCEBLTest
{
    private ISupplierBCEBL Logic { get; }

    public SupplierBCEBLTest()
    {
        Logic = new SupplierBL(
            A.Fake<ISupplierBCERepository>()
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