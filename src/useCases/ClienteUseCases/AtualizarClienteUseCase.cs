using cliente_solution.domain.models;
using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteUseCases;

public class AtualizarClienteUseCase(ClienteRepository repository)
{
    private readonly ClienteRepository _repository = repository;

    public void Executar(int id, string nome, string documento, string email)
    {
        //buscando o cliente
        var cliente = _repository.BuscarPorId(id);

        //a interface estabelece que sempre deve ser retornado um cliente
        //cliente é um objeto, logo, todo o objeto pode ser uma referencia nula


        //logo, esse código não vai funcionar caso o cliente não exista (cliente == null)
        //vamos ter que atualizar os nossos testes para validar esse caso de erro
        cliente.AtualizarDocumento(documento);
        cliente.AtualizarEmail(email);
        cliente.AtualizarNome(nome);

        _repository.Atualizar(cliente);
    }
}
