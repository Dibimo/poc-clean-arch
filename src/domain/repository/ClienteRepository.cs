using cliente_solution.domain.models;

namespace cliente_solution.domain.repository;

//a ideia de criar uma interface é criar um ponteiro para uma implementação, isso ficará mais claro de ser entendido mais tarde.
//o que precisa ser entendido aqui é que uma interface é um contrato.
//ela estabelece O QUE precisa ser feito e o que precisa ser retornado, mas não estabelece O COMO ser feito

//Nota importante: eu vou utilzar um outro padrão de nomenclatura que não é o padrão "comum" do C#.
//no C# normalmente as interfaces são nomeadas com o prefixo "I".
//nesse exemplo, eu vou inteveter e nomear as implementações com o sufixo "Imp". Mas para frente ficará claro o porque disso.
public interface ClienteRepository
{
    //é uma boa pratica retornar os ids das entidades criadas e atualizadas, para indicar que elas foram criadas ou atualizadas com sucesso
    int Adicionar(Cliente cliente);

    int Atualizar(Cliente cliente);

    //retorna um booleano para indicar se o cliente foi removido ou não
    bool Remover(int ClienteId);

    Cliente BuscarPorId(int ClienteId);

    List<Cliente> BuscarTodos();
}