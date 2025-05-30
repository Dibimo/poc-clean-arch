namespace cliente_solution.domain.models;

//vou remover os comentários do passo anterior para deixar mais limpo
public class Cliente : Base
{
    //vamos criar um setter para cada campo
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
        //no último passo vimos que nossa regra não aceita nomes compostos.
        //para corrigir isso vamos fazer uma validação para espaços duplos no nome
        //ter espaço não é errado nome, apenas ter espaços duplos

        //também podemos aproveitar para higienizar o nome, executando um Trim

        if (nome.Length < 3)
            throw new Exception("Nome inválido");

        if (nome.All(char.IsWhiteSpace))
            throw new Exception("Nome inválido");

        var splitedNome = nome.Split(" ");
        if (!splitedNome.SelectMany(x => x).All(char.IsLetter))
            throw new Exception("Nome inválido");

        Nome = nome.Trim(); //esse é o tipo de caso não compensa "validar" e jogar para o usuário corrigir, é melhor que o sistema corrija sozinho
    }

    //com a validação nova adicionada, podemos rodar nossos testes e veremos que todos eles passam normalmente
    //ou seja, não inputmos novos bugs (os casos de antes continuam funionando normalmente)
    //e corrigimos o bug que não permitia nomes compostos

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


    /*
    sim, existem outras abordagens validas para chegar no mesmo resultado

    1. poderia chamar os métodos antigos de "Atualizar" no construtor, ficando assim:

        public Cliente(string nome, string documento, string email)
        {
            AtualizarNome(nome);
            AtualizarDocumento(documento);
            AtualizarEmail(email);
            Contatos = new List<ClienteContato>();
        }
    Mas achei estranho o conceito de estar "construindo algo" (que eu ainda não tenho) e já estar chamando métodos de "Atualizar"

    2. também poderia simplementes renomear os método de "atualizar" para "set", ficando assim:

        public void SetNome(string nome)
        {
            if (nome.Length < 3)
                throw new Exception("Nome inválido");

            if (!nome.All(char.IsLetter))
                throw new Exception("Nome inválido");
            Nome = nome;
        }
    porém o termo "atualizar" deixa o código mais semanântico. Pensando que a regra de negócio é o centro, "atualizar" é um termo de negócio.
    "set" é um termo tecnico da programação.
    Fora que "atualizar" não tira a possibilidade de outras coisas serém feitas junto com o "set" (salvar em um histórico por exemplo)
    agora "set" presume que o valor apenas será atribuido.
    */


}
