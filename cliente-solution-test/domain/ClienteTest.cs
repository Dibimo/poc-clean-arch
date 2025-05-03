using cliente_solution.domain.models;

namespace cliente_solution_test.domain;

public class ClienteTest
{
    //então vamos começar validando as regras do domínio
    //nossa regra de negócio diz que um cliente precisa ter um nome, um documento e um email
    //o nome não pode conter números e precisa ter no minimo 3 caracteres (olhar a classe Cliente)
    //o documento deve conter apenas números e precisa ter no minimo 11 caracteres
    //o email precisa conter um "@"

    //vamos começar validando que o nome não deve conter números
    [Fact]
    public void Ao_criar_nao_deve_aceitar_numeros_no_nome()
    {
        //arrange
        var nome_invalido = "123";
        var documento = "12345678901"; //como estamos validando o nome primeiro, vamos deixar os demais parâmetros validos
        var email = "teste@teste.com.br";

        //act & assert
        Assert.Throws<Exception>(() => new Cliente(nome_invalido, documento, email));
    }

    //se rodarmos o teste, ele vai dar errado. isso porque não estamos validando o nome
    //no construtor, apenas no método de atualização

    //se fizermos o mesmo teste para o método de atualização do nome ele dará certo

    [Fact]
    public void Ao_Atualizar_nome_nao_deve_aceitar_numeros()
    {
        //arrange
        var cliente = new Cliente("nome", "12345678901", "teste@teste.com.br");
        var nome_invalido = "123";

        //act & assert
        Assert.Throws<Exception>(() => cliente.AtualizarNome(nome_invalido)); //esse está correto
    }

    //logo, o que o teste nos mostra é um furo na nossa lógica de negócio.
    //ao criar um cliente eu posso colocar números no nome, mas ao editar o cliente não.

    //vamos corrigir o furo na lógica do cliente

    //implementando os outros testes

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