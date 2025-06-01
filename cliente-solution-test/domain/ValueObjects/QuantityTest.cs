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


    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void Parse_ValidQuantities_ShoudCreateSuccessfully(int value)
    {
        // Act
        var quantity = Quantity.Parse(value);

        // Assert
        Assert.Equal(value, quantity.Value);
    }

    [Fact]
    public void Parse_InvalidQuantity_ShoudThrowArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Quantity.Parse(-1));
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("00010", 10)]
    [InlineData("0000", 0)]
    [InlineData("   1   ", 1)]
    public void Parse_ValidString_ShouldCreateSuccessfully(string quantityString, int quantityValue)
    {
        // Act
        var quantity = Quantity.Parse(quantityString);

        // Assert
        Assert.Equal(quantityValue, quantity.Value);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("1.1")]
    [InlineData("0001.1")]
    [InlineData("   1.1   ")]
    public void Parse_InvalidString_ShouldThrowArgumentException(string quantityString)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Quantity.Parse(quantityString));
    }
}