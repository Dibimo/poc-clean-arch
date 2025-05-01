namespace cliente_solution.domain.models;

public class Cliente : Base
{
    //Precisamos acessar os atributos, mas queremos que eles não sejam editaveis
    public string Nome { get; private set; }

    public string Documento { get; private set; }

    public string Email { get; private set; }

    public ICollection<ClienteContato> Contatos { get; private set; }

    //aqui estamos definido a nossa regra de negócio, eu não posso ter um cliente sem um nome, documento e email
    public Cliente(string nome, string documento, string email)
    {
        Nome = nome;
        Documento = documento;
        Email = email;
        Contatos = new List<ClienteContato>();
    }

    //como nossas atributos não podem ser alterados por quem chama a nossa classe de cliente, precisamos expor o que é possível fazer com ela.
    //isso é feito por meio dos métodos publicos.
    //assim podemos controlar o que é feito com os nossos dados e garantir que todas as nossas regras sejam corretamente aplicadas.

    //nesse caso, eu vou só validar se existe um "@" no email que está sendo passado para minha classe.
    public void AtualizarEmail(string email)
    {
        if (!email.Contains("@"))
            throw new Exception("Email inválido"); //o correto nesse caso séria ter um tipo de Exception personalizado, mas para fins didácticos, vou deixar assim.

        Email = email;
    }

    //vou fazer a mesma coisa com os outros dois campos

    //a regra que eu quero no documento é ver se ele tem pelo menos 11 caracteres e se ele contém apenas números
    public void AtualizarDocumento(string documento)
    {
        if (documento.Length < 11)
            throw new Exception("Documento inválido");

        if (!documento.All(char.IsDigit))
            throw new Exception("Documento inválido");

        Documento = documento;
    }

    //no caso do nome, vou ver se ele tem pelo menos 3 caracteres e se ele contém apenas letras
    public void AtualizarNome(string nome)
    {
        if (nome.Length < 3)
            throw new Exception("Nome inválido");

        if (!nome.All(char.IsLetter))
            throw new Exception("Nome inválido");

        Nome = nome;
    }


}
