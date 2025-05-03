using cliente_solution.domain.models;
using Xunit;

namespace cliente_solution_test.domain;

public class ClienteContatoTest
{
    public static IEnumerable<object[]> ClienteContatosValidos =>
        new List<object[]>
        {
            new object[] { "Leticia", "leticia@teste.com", "11999999999", 1 },
            new object[] { "Pitas", "pitas@pipas.com", "11939593399", 1 },
            new object[] { "Mariana", "mariana@teste.com", "11999999999", 1 }

        };

    // Casos inválidos para nome
    [Theory]
    [InlineData("12")] // menos de 3 caracteres
    [InlineData("123")] // números
    [InlineData("abc1")] // letras e números
    [InlineData(" ")] // espaço
    [InlineData("")]
    public void CriarContato_NomeInvalido_DeveLancarException(string nomeInvalido)
    {
        // arrange
        var email = "teste@teste.com";
        var telefone = "11999999999";
        var clienteId = 1;
        // act & assert
        Assert.Throws<Exception>(() => new ClienteContato(nomeInvalido, email, telefone, clienteId));
    }

    [Theory]
    [InlineData("12")]
    [InlineData("123")]
    [InlineData("abc1")]
    [InlineData(" ")]
    [InlineData("")]
    public void AtualizarContato_NomeInvalido_DeveLancarException(string nomeInvalido)
    {
        var contato = new ClienteContato("NomeValido", "teste@teste.com", "11999999999", 1);
        Assert.Throws<Exception>(() => contato.AtualizarNome(nomeInvalido));
    }

    // Casos inválidos para email
    [Theory]
    [InlineData("email")]
    [InlineData("email.com")]
    [InlineData("")]
    public void CriarContato_EmailInvalido_DeveLancarException(string emailInvalido)
    {
        var nome = "NomeValido";
        var telefone = "11999999999";
        var clienteId = 1;
        Assert.Throws<Exception>(() => new ClienteContato(nome, emailInvalido, telefone, clienteId));
    }

    [Theory]
    [InlineData("email")]
    [InlineData("email.com")]
    [InlineData("")]
    public void AtualizarContato_EmailInvalido_DeveLancarException(string emailInvalido)
    {
        var contato = new ClienteContato("NomeValido", "teste@teste.com", "11999999999", 1);
        Assert.Throws<Exception>(() => contato.AtualizarEmail(emailInvalido));
    }

    // Casos inválidos para telefone
    [Theory]
    [InlineData("123456789")] // menos de 10 dígitos
    [InlineData("123456789a")] // contém letra
    [InlineData("123456789!")] // contém símbolo
    [InlineData("")]
    public void CriarContato_TelefoneInvalido_DeveLancarException(string telefoneInvalido)
    {
        var nome = "NomeValido";
        var email = "teste@teste.com";
        var clienteId = 1;
        Assert.Throws<Exception>(() => new ClienteContato(nome, email, telefoneInvalido, clienteId));
    }

    [Theory]
    [InlineData("123456789")]
    [InlineData("123456789a")]
    [InlineData("123456789!")]
    [InlineData("")]
    public void AtualizarContato_TelefoneInvalido_DeveLancarException(string telefoneInvalido)
    {
        var contato = new ClienteContato("NomeValido", "teste@teste.com", "11999999999", 1);
        Assert.Throws<Exception>(() => contato.AtualizarTelefone(telefoneInvalido));
    }

    // Caso de sucesso para criação
    [Theory]
    [MemberData(nameof(ClienteContatosValidos))]
    public void CriarContato_Valido_DeveCriarContato(string nome, string email, string telefone, int clienteId)
    {
        var exception = Record.Exception(() => new ClienteContato(nome, email, telefone, clienteId));
        Assert.Null(exception);
    }

    // Caso de sucesso para atualização
    [Fact]
    public void AtualizarContato_ValoresValidos_NaoDeveLancarException()
    {
        var contato = new ClienteContato("NomeValido", "teste@teste.com", "11999999999", 1);
        var exceptionNome = Record.Exception(() => contato.AtualizarNome("OutroNome"));
        var exceptionEmail = Record.Exception(() => contato.AtualizarEmail("novo@email.com"));
        var exceptionTelefone = Record.Exception(() => contato.AtualizarTelefone("21988887777"));
        Assert.Null(exceptionNome);
        Assert.Null(exceptionEmail);
        Assert.Null(exceptionTelefone);
    }
}
