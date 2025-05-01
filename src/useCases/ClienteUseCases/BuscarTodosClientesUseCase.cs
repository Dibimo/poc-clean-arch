using cliente_solution.domain.models;
using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteUseCases;

public class BuscarTodosClientesUseCase(ClienteRepository repository)
{
    private readonly ClienteRepository _repository = repository;

    public List<Cliente> Executar()
    {
        return _repository.BuscarTodos();
    }
}
