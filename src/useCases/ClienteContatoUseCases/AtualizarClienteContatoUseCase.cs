using cliente_solution.domain.models;
using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteContatoUseCases;

public class AtualizarClienteContatoUseCase(ClienteContatoRepository repository)
{
    private readonly ClienteContatoRepository _repository = repository;

    public void Executar(int id, string nome, string email, string telefone)
    {
        var contato = _repository.BuscarPorId(id);
        contato.AtualizarNome(nome);
        contato.AtualizarEmail(email);
        contato.AtualizarTelefone(telefone);
        _repository.Atualizar(contato);
    }
}
