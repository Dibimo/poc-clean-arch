using cliente_solution.domain.models;
using cliente_solution.domain.repository;
using cliente_solution.useCases.Exceptions;

namespace cliente_solution.useCases.ClienteUseCases;

public class AtualizarClienteUseCase(ClienteRepository repository)
{
    private readonly ClienteRepository _repository = repository;

    public void Executar(int id, string nome, string documento, string email)
    {
        //implementando o lançamento da exceção corretamente
        var cliente = _repository.BuscarPorId(id) ?? throw new EntidadeNaoExistente("cliente", id);

        cliente.AtualizarDocumento(documento);
        cliente.AtualizarEmail(email);
        cliente.AtualizarNome(nome);

        _repository.Atualizar(cliente);
    }
}
