using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteUseCases;

public class RemoverClienteUseCase(ClienteRepository repository)
{
    private readonly ClienteRepository _repository = repository;

    public bool Executar(int ClienteId)
    {
        return _repository.Remover(ClienteId);
    }
}
