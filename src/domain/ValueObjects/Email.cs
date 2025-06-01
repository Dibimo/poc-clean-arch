using System.Text.RegularExpressions;

namespace cliente_solution.domain.ValueObjects;


public partial class Email : IEquatable<Email>
{
    private static readonly Regex EmailRegex = MyRegex();

    public string Value { get; }

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O e-mail não pode ser nulo ou vazio.", nameof(email));

        var normalizedEmail = email.Trim().ToLowerInvariant();

        if (!IsValidEmail(normalizedEmail))
            throw new ArgumentException("O e-mail informado não é valido.", nameof(email));

        Value = normalizedEmail;
    }

    public static bool IsValidEmail(string email) => EmailRegex.IsMatch(email);

    public bool Equals(Email? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }

    public override bool Equals(object? obj) => Equals(obj as Email);

    public static bool operator ==(Email? left, Email? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Email? left, Email? right)
    {
        return !(left == right);
    }

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;

    public static Email Parse(string email) => new(email);

    public static bool TryParse(string email, out Email emailValue)
    {
        try
        {
            emailValue = new Email(email);
            return true;
        }
        catch (ArgumentException)
        {
            emailValue = null;
            return false;
        }
    }

    public static implicit operator string(Email email) => email.Value;

    public static implicit operator Email(string email) => new(email);

    [GeneratedRegex(@"^(?!.*\.\.)[a-zA-Z0-9](\.?[a-zA-Z0-9_\-+]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.[a-zA-Z]{2,}$", RegexOptions.IgnoreCase | RegexOptions.Compiled, "pt-BR")]
    private static partial Regex MyRegex();
}