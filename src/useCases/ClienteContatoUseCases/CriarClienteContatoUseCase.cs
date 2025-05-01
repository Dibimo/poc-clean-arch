using cliente_solution.domain.models;
using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteContatoUseCases;

public class CriarClienteContatoUseCase(ClienteContatoRepository repository)
{
    private readonly ClienteContatoRepository _repository = repository;

    public void Executar(int clienteId,string nome, string email, string telefone)
    {
        //como adicionamos o id do cliente, precisamos passar ele como parâmetro para o construtor
        //também vou aproveitar para remover o cliente id do método de adicionar, ele não é necessário.
        //(cuidado ao pedir para a IA fazer as coisas por vocé)
        var contato = new ClienteContato(nome, email, telefone, clienteId);
        _repository.Adicionar(contato);
    }
}
