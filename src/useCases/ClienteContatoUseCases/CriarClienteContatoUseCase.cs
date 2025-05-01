using cliente_solution.domain.models;
using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteContatoUseCases;

public class CriarClienteContatoUseCase(ClienteContatoRepository repository)
{
    private readonly ClienteContatoRepository _repository = repository;

    public void Executar(int clienteId,string nome, string email, string telefone)
    {
        var contato = new ClienteContato(nome, email, telefone);
        _repository.Adicionar(clienteId, contato);
    }
}
