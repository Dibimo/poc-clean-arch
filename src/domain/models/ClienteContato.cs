namespace cliente_solution.domain.models;

public class ClienteContato : Base{
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public string Telefone { get; private set; }

    public ClienteContato(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    //seguindo o mesmo padrão da classe de cliente, vou implementar os métodos de atualização
    public void AtualizarEmail(string email)
    {
        if (!email.Contains("@"))
            throw new Exception("Email inválido");

        Email = email;
    }

    public void AtualizarTelefone(string telefone)
    {
        if (telefone.Length < 10)
            throw new Exception("Telefone inválido");

        if (!telefone.All(char.IsDigit))
            throw new Exception("Telefone inválido");

        Telefone = telefone;
    }


    public void AtualizarNome(string nome)
    {
        if (nome.Length < 3)
            throw new Exception("Nome inválido");

        if (!nome.All(char.IsLetter))
            throw new Exception("Nome inválido");
        Nome = nome;
    }
}