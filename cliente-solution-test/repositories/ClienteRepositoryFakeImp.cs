

using cliente_solution.domain.models;
using cliente_solution.domain.repository;
using SQLitePCL;

namespace cliente_solution_test.repositories;

public class ClienteRepositoryFakeImp : ClienteRepository
{
    //para fazer o teste eu não preciso mockar o banco de dados
    //só precisamos de um lugar para o use case "tirar os dados"
    //então uma lista em memória mesmo já é o bastante
    private int currentId = 1;
    private readonly List<Cliente> _clientes = new();

    public ClienteRepositoryFakeImp()
    {
        _clientes.Add(GenereteCliente(currentId++, "João", "12345678901", "j@j.com"));
        _clientes.Add(GenereteCliente(currentId++, "Maria", "12345678901", "m@m.com"));
        _clientes.Add(GenereteCliente(currentId++, "Pedro", "12345678901", "p@p.com"));
    }

    private static Cliente GenereteCliente(int id,string nome, string documento, string email)
    {
        var cliente = new Cliente(nome, documento, email);
        cliente.Id = id;
        return cliente;
    }

    public int Adicionar(Cliente cliente)
    {
        cliente.Id = currentId++;
        _clientes.Add(cliente);
        return cliente.Id;
    }

    public int Atualizar(Cliente cliente)
    {
        var clienteExistente = _clientes.FindIndex(x => x.Id == cliente.Id);

        _clientes[clienteExistente] = cliente;

        return cliente.Id;
    }

    public Cliente BuscarPorId(int ClienteId)
    {
        return _clientes.Find(x => x.Id == ClienteId);
    }

    public List<Cliente> BuscarTodos()
    {
        return _clientes;
    }

    public bool Remover(int ClienteId)
    {
        var clienteExistente = _clientes.FindIndex(x => x.Id == ClienteId);
        _clientes.RemoveAt(clienteExistente);
        return true;
    }
}