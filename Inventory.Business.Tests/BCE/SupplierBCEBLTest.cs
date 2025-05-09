using FakeItEasy;
using Inventory.Business.BCE;
using Inventory.IBusiness.BCE;
using Inventory.IDAL.BCE;
using Xunit;

namespace Inventory.Business.Tests.BCE;

public class SupplierBCEBLTest
{
    private ISupplierBCEBL Logic { get; }

    public SupplierBCEBLTest()
    {
        Logic = new SupplierBCEBL(
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