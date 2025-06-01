namespace cliente_solution.domain.models;

public class Cliente : Base
{
    public string Nome { get; private set; }

    public string Documento { get; private set; }

    public string Email { get; private set; }

    public ICollection<ClienteContato> Contatos { get; private set; }

    public Cliente(string nome, string documento, string email)
    {
        SetNome(nome);
        SetDocumento(documento);
        SetEmail(email);
        Contatos = new List<ClienteContato>();
    }

    public void AtualizarEmail(string email)
        => SetEmail(email);

    public void AtualizarDocumento(string documento)
        => SetDocumento(documento);

    public void AtualizarNome(string nome)
        => SetNome(nome);

    private void SetNome(string nome)
    {


        if (nome.Length < 3)
            throw new Exception("Nome inválido");

        if (nome.All(char.IsWhiteSpace))
            throw new Exception("Nome inválido");

        var splitedNome = nome.Split(" ");
        if (!splitedNome.SelectMany(x => x).All(char.IsLetter))
            throw new Exception("Nome inválido");

    }


    private void SetDocumento(string documento)
    {
        if (documento.Length < 11)
            throw new Exception("Documento inválido");

        if (!documento.All(char.IsDigit))
            throw new Exception("Documento inválido");

        Documento = documento;
    }

    private void SetEmail(string email)
    {
        if (!email.Contains("@"))
            throw new Exception("Email inválido");

        Email = email;
    }

}
