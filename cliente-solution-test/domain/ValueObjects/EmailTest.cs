namespace cliente_solution_test.domain.ValueObjects;

using cliente_solution.domain.ValueObjects;

public class EmailTest
{
    [Theory]
    [InlineData("user@example.com")]
    [InlineData("test.email@domain.co.uk")]
    [InlineData("user+tag@example.org")]
    [InlineData("123@numbers.com")]
    public void Constructor_ValidEmails_ShouldCreateSuccessfully(string validEmail)
    {
        // Act
        var email = new Email(validEmail);

        // Assert
        Assert.Equal(validEmail.ToLowerInvariant(), email.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("invalid-email")]
    [InlineData("@example.com")]
    [InlineData("user@")]
    [InlineData("user..double@example.com")]
    [InlineData("user@.com")]
    public void Constructor_InvalidEmails_ShouldThrowArgumentException(string invalidEmail)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Email(invalidEmail));
    }

    [Fact]
    public void Constructor_EmailWithSpaces_ShouldTrimAndNormalize()
    {
        // Arrange
        var emailWithSpaces = "  USER@EXAMPLE.COM  ";

        // Act
        var email = new Email(emailWithSpaces);

        // Assert
        Assert.Equal("user@example.com", email.Value);
    }

    [Fact]
    public void Equals_SameEmailValues_ShouldReturnTrue()
    {
        // Arrange
        var email1 = new Email("test@example.com");
        var email2 = new Email("TEST@EXAMPLE.COM");

        // Act & Assert
        Assert.True(email1.Equals(email2));
        Assert.True(email1 == email2);
    }

    [Fact]
    public void Equals_DifferentEmailValues_ShouldReturnFalse()
    {
        // Arrange
        var email1 = new Email("test1@example.com");
        var email2 = new Email("test2@example.com");

        // Act & Assert
        Assert.False(email1.Equals(email2));
        Assert.False(email1 == email2);
    }

    [Fact]
    public void Equals_ComparedWithNull_ShouldReturnFalse()
    {
        // Arrange
        var email = new Email("test@example.com");

        // Act & Assert
        Assert.False(email.Equals(null));
        Assert.False(email == null);
    }

    [Fact]
    public void GetHashCode_SameEmails_ShouldReturnSameHashCode()
    {
        // Arrange
        var email1 = new Email("test@example.com");
        var email2 = new Email("TEST@EXAMPLE.COM");

        // Act & Assert
        Assert.Equal(email1.GetHashCode(), email2.GetHashCode());
    }

    [Fact]
    public void ToString_ShouldReturnEmailValue()
    {
        // Arrange
        var emailValue = "test@example.com";
        var email = new Email(emailValue);

        // Act & Assert
        Assert.Equal(emailValue, email.ToString());
    }

    [Fact]
    public void ImplicitConversion_EmailToString_ShouldWork()
    {
        // Arrange
        Email email = "test@example.com";

        // Act
        string emailAsString = email;

        // Assert
        Assert.Equal("test@example.com", emailAsString);
    }

    [Fact]
    public void ExplicitConversion_StringToEmail_ShouldWork()
    {
        // Arrange
        var emailString = "test@example.com";

        // Act
        var email = (Email)emailString;

        // Assert
        Assert.Equal(emailString, email.Value);
    }

    [Fact]
    public void Parse_ValidEmail_ShouldReturnEmailObject()
    {
        // Arrange
        var emailString = "test@example.com";

        // Act
        var email = Email.Parse(emailString);

        // Assert
        Assert.Equal(emailString, email.Value);
    }

    [Fact]
    public void Parse_InvalidEmail_ShouldThrowArgumentException()
    {
        // Arrange
        var invalidEmail = "invalid-email";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Email.Parse(invalidEmail));
    }

    [Fact]
    public void TryParse_ValidEmail_ShouldReturnTrueAndEmail()
    {
        // Arrange
        var emailString = "test@example.com";

        // Act
        var success = Email.TryParse(emailString, out Email email);

        // Assert
        Assert.True(success);
        Assert.NotNull(email);
        Assert.Equal(emailString, email.Value);
    }

    [Fact]
    public void TryParse_InvalidEmail_ShouldReturnFalseAndNullEmail()
    {
        // Arrange
        var invalidEmail = "invalid-email";

        // Act
        var success = Email.TryParse(invalidEmail, out Email email);

        // Assert
        Assert.False(success);
        Assert.Null(email);
    }

    [Fact]
    public void EmailsInHashSet_ShouldWorkCorrectlyForLookup()
    {
        // Arrange
        var emails = new HashSet<Email>
        {
            new Email("user1@example.com"),
            new Email("user2@example.com"),
            new Email("USER1@EXAMPLE.COM") // Mesmo que o primeiro, mas case diferente
        };

        // Act & Assert
        Assert.Equal(2, emails.Count); // Deve ter apenas 2 emails únicos
        Assert.Contains(new Email("user1@example.com"), emails);
    }

}