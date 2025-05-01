using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteContatoUseCases;

public class RemoverClienteContatoUseCase(ClienteContatoRepository repository)
{
    private readonly ClienteContatoRepository _repository = repository;

    public bool Executar(int clienteContatoId)
    {
        return _repository.Remover(clienteContatoId);
    }
}
