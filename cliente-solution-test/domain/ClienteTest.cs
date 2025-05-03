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


    [Fact]
    public void Ao_Atualizar_nome_nao_deve_aceitar_numeros()
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");
        var nome_invalido = "123";

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarNome(nome_invalido)); //esse está correto
    }


    [Fact]
    public void Ao_criar_nao_deve_aceitar_nomes_menores_que_3_caracteres()
    {
        //arrange
        var nome_invalido = "d";
        var documento = "12345678901"; //como estamos validando o nome primeiro, vamos deixar os demais parâmetros validos
        var email = "teste@teste.com.br";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome_invalido, documento, email));
    }

    [Fact]
    public void Ao_Atualizar_nome_nao_deve_aceitar_nomes_menores_que_3_caracteres()
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");
        var nome_invalido = "d";

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarNome(nome_invalido));
    }

    [Fact]

    public void Ao_criar_nao_deve_aceitar_letras_no_documento()
    {
        //arrange
        var nome = "nome";
        var documento_invalido = "123456789a";
        var email = "teste@teste.com.br";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome, documento_invalido, email));
    }

    [Fact]
    public void Ao_Atualizar_documento_nao_deve_aceitar_letras()
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");
        var documento_invalido = "123456789a";

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarDocumento(documento_invalido));
    }

    [Fact]
    public void Ao_criar_nao_deve_aceitar_documentos_menores_que_11_caracteres()
    {
        //arrange
        var nome = "nome";
        var documento_invalido = "123456789";
        var email = "teste@teste.com.br";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome, documento_invalido, email));
    }

    [Fact]
    public void Ao_Atualizar_documento_nao_deve_aceitar_documentos_menores_que_11_caracteres()
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");
        var documento_invalido = "123456789";

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarDocumento(documento_invalido));
    }

    [Fact]
    public void Ao_criar_nao_deve_aceitar_emails_sem_arroba()
    {
        //arrange
        var nome = "nome";
        var documento = "12345678901";
        var email_invalido = "email";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome, documento, email_invalido));
    }

    [Fact]
    public void Ao_Atualizar_email_nao_deve_aceitar_emails_sem_arroba()
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");
        var email_invalido = "email";

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarEmail(email_invalido));
    }


}