namespace cliente_solution.domain.ValueObjects;


public class Quantity : IEquatable<Quantity>
{
    public int Value { get; }

    public Quantity(int value)
    {
        if (!IsQuantityValid(value))
            throw new ArgumentException("A quantidade deve ser maior ou igual a zero.", nameof(value));

        Value = value;
    }

    private static bool IsQuantityValid(int value)
    {
        return value >= 0;
    }

    public bool Equals(Quantity? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }

    public override bool Equals(object? obj) => Equals(obj as Quantity);

    public static bool operator ==(Quantity? left, Quantity? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Quantity? left, Quantity? right) => !(left == right);

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value.ToString();

    public static implicit operator int(Quantity quantity) => quantity.Value;

    public static implicit operator Quantity(int value) => new(value);

    public static bool TryParse(int value, out Quantity quantity)
    {
        try
        {
            quantity = Parse(value);
            return true;
        }
        catch (ArgumentException)
        {
            quantity = null;
            return false;
        }
    }

    public static bool TryParse(string value, out Quantity quantity)
    {
        try
        {
            quantity = Parse(value);
            return true;
        }
        catch (ArgumentException)
        {
            quantity = null;
            return false;
        }
    }

    public static Quantity Parse(int value) => new(value);

    public static Quantity Parse(string value)
    {
        var parseSuccessfully = int.TryParse(value, out var quantityValue);
        return parseSuccessfully ? new Quantity(quantityValue) : throw new ArgumentException("A quantidade não é valida.", nameof(value));
    }




}