using cliente_solution.domain.models;

namespace cliente_solution_test.domain;

public class ClienteTest
{
    /*
        o [Fact] é para casos onde temos um cenário de teste.
        se quisermos, e é recomendado, que testemos mais de um cenário de teste, podemos usar o [Theory]
    */
    [Theory]
    [InlineData("123")] //teste que já tinhamos antes
    [InlineData("1234W")] //letras e numeros
    [InlineData("     ")]//espaco em branco
    public void CriarCliente_NomeComNaoAlfabeticos_DeveLancarException(string nome_invalido)
    {
        //arrange
        var documento = "12345678901";
        var email = "teste@teste.com.br";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome_invalido, documento, email));
    }

    //se rodarmos o teste, veremos que ele da certo. Ou seja... nossa classe de cliente não apenas não aceita números, como também valida espaços em branco

    //então podemos renomear o teste para ficar mais claro qual de fato é nossa regra.
    //sempre bom lembrar: testes também servem como documentação de regras
    //Ao_criar_nao_deve_aceitar_numeros_no_nome -> CriarCliente_NomeComNaoAlfabeticos_DeveLancarException


    [Theory]
    [InlineData("123")]
    [InlineData("1234W")]
    [InlineData("     ")]
    public void AtualizarCliente_NomeComNaoAlfabeticos_DeveLancarException(string nomeInvalido)
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarNome(nomeInvalido));
    }


    //nesse caso, não precisamos de uma Theory, pois de fato, existe apenas um cenário valiado para a regra
    [Fact]
    public void CriarCliente_NomeMenorQue3_DeveLancarException()
    {
        //arrange
        var nome_invalido = "d";
        var documento = "12345678901"; //como estamos validando o nome primeiro, vamos deixar os demais parâmetros validos
        var email = "teste@teste.com.br";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome_invalido, documento, email));
    }

    [Fact]
    public void AtualizarCliente_NomeMenorQue3_DeveLancarException()
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");
        var nome_invalido = "d";

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarNome(nome_invalido));
    }

    [Theory]
    [InlineData("123456789a")]
    [InlineData("123456789 ")]
    public void CriarCliente_DocumentoComNaoNumeros_DeveLancarException(string documentoInvalido)
    {
        //arrange
        var nome = "nome";
        var email = "teste@teste.com.br";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome, documentoInvalido, email));
    }

    [Theory]
    [InlineData("123456789a")]
    [InlineData("123456789 ")]
    public void AtualizarCliente_DocumentoComNaoNumeros_DeveLancarException(string documentoInvalido)
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarDocumento(documentoInvalido));
    }

    [Fact]
    public void CriarCliente_DocumentoMenorQue11Caracteres_DeveLancarException()
    {
        //arrange
        var nome = "nome";
        var documento_invalido = "123456789";
        var email = "teste@teste.com.br";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome, documento_invalido, email));
    }

    [Fact]
    public void AtualizarCliente_DocumentoMenorQue11Caracteres_DeveLancarException()
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");
        var documento_invalido = "123456789";

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarDocumento(documento_invalido));
    }

    [Fact]
    public void CriarCliente_ComEmailSemArroba_DeveLancarException()
    {
        //arrange
        var nome = "nome";
        var documento = "12345678901";
        var email_invalido = "email";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome, documento, email_invalido));
    }

    [Fact]
    public void AtualizarCliente_ComEmailSemArroba_DeveLancarException()
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");
        var email_invalido = "email";

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarEmail(email_invalido));
    }


}