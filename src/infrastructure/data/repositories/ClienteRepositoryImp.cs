namespace cliente_solution.infrastructure.data.repositories;

using System.Collections.Generic;
using cliente_solution.domain.models;
using cliente_solution.domain.repository;
using Microsoft.EntityFrameworkCore;

public class ClienteRepositoryImp : ClienteRepository
{
    private readonly ClienteSolutionContext _context;
    public ClienteRepositoryImp(ClienteSolutionContext context)
    {
        _context = context;
    }

    public int Adicionar(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return cliente.Id;
    }

    public int Atualizar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
        return cliente.Id;
    }

    public Cliente BuscarPorId(int ClienteId)
    {
        return _context.Clientes.Include(x => x.Contatos).FirstOrDefault(x => x.Id == ClienteId);
    }

    public List<Cliente> BuscarTodos()
    {
        return _context.Clientes.ToList();
    }

    public bool Remover(int ClienteId)
    {
        var cliente = BuscarPorId(ClienteId);
        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return true;
    }
}