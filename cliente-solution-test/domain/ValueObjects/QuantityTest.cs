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

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void TryParse_ValidQuantities_ShoudCreateSuccessfully(int value)
    {
        // Act
        var result = Quantity.TryParse(value, out var quantity);

        // Assert
        Assert.True(result);
        Assert.Equal(value, quantity.Value);
    }

    [Fact]
    public void TryParse_InvalidQuantity_ShoudThrowArgumentException()
    {
        // Act
        var result = Quantity.TryParse(-1, out var quantity);

        // Assert
        Assert.False(result);
        Assert.Null(quantity);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("00010", 10)]
    [InlineData("0000", 0)]
    [InlineData("   1   ", 1)]
    public void TryParse_ValidString_ShouldCreateSuccessfully(string quantityString, int quantityValue)
    {
        // Act
        var result = Quantity.TryParse(quantityString, out var quantity);

        // Assert
        Assert.True(result);
        Assert.Equal(quantityValue, quantity.Value);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("1.1")]
    [InlineData("0001.1")]
    [InlineData("   1.1   ")]
    public void TryParse_InvalidString_ShouldThrowArgumentException(string quantityString)
    {
        // Act
        var result = Quantity.TryParse(quantityString, out var quantity);

        // Assert
        Assert.False(result);
        Assert.Null(quantity);
    }


    [Fact]
    public void Equals_SameQuantityValues_ShouldReturnTrue()
    {
        // Arrange
        var quantity1 = new Quantity(5);
        var quantity2 = new Quantity(5);

        // Act & Assert
        Assert.True(quantity1.Equals(quantity2));
        Assert.True(quantity1 == quantity2);
        Assert.False(quantity1 != quantity2);
    }

    [Fact]
    public void Equals_DifferentQuantityValues_ShouldReturnFalse()
    {
        // Arrange
        var quantity1 = new Quantity(5);
        var quantity2 = new Quantity(10);

        // Act & Assert
        Assert.False(quantity1.Equals(quantity2));
        Assert.False(quantity1 == quantity2);
        Assert.True(quantity1 != quantity2);
    }

    [Fact]
    public void Equals_ComparedWithNull_ShouldReturnFalse()
    {
        // Arrange
        var quantity1 = new Quantity(5);

        // Act & Assert
        Assert.False(quantity1.Equals(null));
        Assert.False(quantity1 == null);
        Assert.True(quantity1 != null);
    }

    [Fact]
    public void GetHashCode_SameValues_ShouldReturnSameHashCode()
    {
        // Arrange
        var quantity1 = new Quantity(10);
        var quantity2 = new Quantity(10);

        // Act & Assert
        Assert.Equal(quantity1.GetHashCode(), quantity2.GetHashCode());
    }

    [Fact]
    public void QuantitiesInHashSet_ShouldWorkCorrectlyForLookup()
    {
        // Arrange
        var quantities = new HashSet<Quantity>
        {
            new(1),
            new(2),
            new(1)
        };

        // Act & Assert
        Assert.Equal(2, quantities.Count); // deve ter apenas 2 valores únicos
        Assert.Contains(new Quantity(1), quantities);
    }

    [Fact]
    public void ToString_ShouldReturnQuantityValueAsString()
    {
        // Arrange
        var quantity = new Quantity(42);

        // Act
        var str = quantity.ToString();

        // Assert
        Assert.Equal("42", str);
    }

    [Fact]
    public void ImplicitConversion_QuantityToInt_ShouldWork()
    {
        // Arrange
        var quantity = new Quantity(7);

        // Act
        int value = quantity;

        // Assert
        Assert.Equal(7, value);
    }

    [Fact]
    public void ImplicitConversion_IntToQuantity_ShouldWork()
    {
        // Arrange
        int value = 15;

        // Act
        Quantity quantity = value;

        // Assert
        Assert.Equal(15, quantity.Value);
    }


    [Fact]
    public void ExplicitConversion_IntToQuantity_ShouldWork()
    {
        // Arrange
        var intQuantity = 7;

        // Act
        var quantity = (Quantity)intQuantity;

        // Assert
        Assert.Equal(intQuantity, quantity.Value);
    }

}