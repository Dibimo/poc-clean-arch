using cliente_solution.domain.models;

namespace cliente_solution.domain.repository;

//apenas seguindo a mesma lógica do ClienteRepository
public interface ClienteContatoRepository
{
    int Adicionar(ClienteContato contato);

    int Atualizar(ClienteContato contato);

    bool Remover(int clienteContatoId);

    ClienteContato BuscarPorId(int clienteContatoId);

    List<ClienteContato> BuscarTodos(int ClienteId);
}