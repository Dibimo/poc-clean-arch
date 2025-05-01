using cliente_solution.domain.models;
using cliente_solution.useCases.ClienteUseCases;
using Microsoft.AspNetCore.Mvc;

namespace cliente_solution.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController (
    CriarClienteUseCase criarClienteUseCase,
    BuscarTodosClientesUseCase buscarTodosClientesUseCase,
    AtualizarClienteUseCase atualizarClienteUseCase,
    RemoverClienteUseCase removerClienteUseCase

) : ControllerBase
{
    //agora que temos os casos de uso programados, podemos implementar as rotas da nossa API
    //para chamar os casos de uso basta receber pelo construtor
    //(para ver como registrar os casos de uso, só olhar o Program.cs)

    //caso seja necessário uma lógica entre vários casos de uso, podemos criar um service para isso.
    //também pode ser uma saida valida se precisamos de um tratamento de exceções com uma lógica propia.
    //por hora, vou deixar como está

    [HttpGet]
    public List<Cliente> BuscarTodos()
    {
        return buscarTodosClientesUseCase.Executar();
    }

    [HttpPost]
    public void Criar(string nome, string documento, string email)
    {
        criarClienteUseCase.Executar(nome, documento, email);
    }

    [HttpPut]
    public void Atualizar(int id, string nome, string documento, string email)
    {
        atualizarClienteUseCase.Executar(id, nome, documento, email);
    }

    [HttpDelete]
    public void Remover(int id)
    {
        removerClienteUseCase.Executar(id);
    }
}