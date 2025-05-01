using cliente_solution.domain.models;
using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteContatoUseCases;

public class BuscarTodosClienteContatosUseCase(ClienteContatoRepository repository)
{
    private readonly ClienteContatoRepository _repository = repository;

    public List<ClienteContato> Executar(int clienteId)
    {
        return _repository.BuscarTodos(clienteId);
    }
}
