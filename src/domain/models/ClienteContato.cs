namespace cliente_solution.domain.models;

public class ClienteContato : Base{
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public string Telefone { get; private set; }

    public int ClienteId { get; private set; }
    public Cliente Cliente { get; private set; }

    public ClienteContato(string nome, string email, string telefone, int clienteId)
    {
        SetNome(nome);
        SetEmail(email);
        SetTelefone(telefone);
        ClienteId = clienteId;
    }

    //seguindo o mesmo padrão da classe de cliente, vou implementar os métodos de atualização
    public void AtualizarEmail(string email)
        => SetEmail(email);

    public void AtualizarTelefone(string telefone)
        => SetTelefone(telefone);


    public void AtualizarNome(string nome)
        => SetNome(nome);

    private void SetNome(string nome)
    {
        if (nome.Length < 3)
            throw new Exception("Nome inválido");

        if (!nome.All(char.IsLetter))
            throw new Exception("Nome inválido");

        var splitedNome = nome.Split(" ");
        if (!splitedNome.SelectMany(x => x).All(char.IsLetter))
            throw new Exception("Nome inválido");

        Nome = nome;
    }

    private void SetEmail(string email)
    {
        if (!email.Contains("@"))
            throw new Exception("Email inválido");

        Email = email;
    }

    private void SetTelefone(string telefone)
    {
        if (telefone.Length < 10)
            throw new Exception("Telefone invildo");

        if (!telefone.All(char.IsDigit))
            throw new Exception("Telefone invildo");

        Telefone = telefone;
    }
}