using cliente_solution.domain.ValueObjects;

namespace cliente_solution_test.domain.ValueObjects;


public class QuantityTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void Constructor_ValidQuantities_ShoudCreateSuccessfully(int value)
    {
        // Act
        var quantity = new Quantity(value);

        // Assert
        Assert.Equal(value, quantity.Value);
    }

    [Fact]
    public void Constructor_InvalidQuantities_ShoudThrowArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Quantity(-1));
    }

}