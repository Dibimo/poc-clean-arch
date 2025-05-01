using cliente_solution.domain.models;
using cliente_solution.useCases.ClienteContatoUseCases;
using Microsoft.AspNetCore.Mvc;

namespace cliente_solution.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteContatoController (
    CriarClienteContatoUseCase criarClienteContatoUseCase,
    BuscarTodosClienteContatosUseCase buscarTodosClienteContatosUseCase,
    AtualizarClienteContatoUseCase atualizarClienteContatoUseCase,
    RemoverClienteContatoUseCase removerClienteContatoUseCase
) : ControllerBase
{
    [HttpGet]
    public List<ClienteContato> BuscarTodos(int clienteId)
    {
        return buscarTodosClienteContatosUseCase.Executar(clienteId);
    }

    [HttpPost]
    public void Criar(int clienteId, string nome, string email, string telefone)
    {
        criarClienteContatoUseCase.Executar(clienteId, nome, email, telefone);
    }

    [HttpPut]
    public void Atualizar(int id, string nome, string email, string telefone)
    {
        atualizarClienteContatoUseCase.Executar(id, nome, email, telefone);
    }

    [HttpDelete]
    public bool Remover(int clienteContatoId)
    {
        return removerClienteContatoUseCase.Executar(clienteContatoId);
    }
}
