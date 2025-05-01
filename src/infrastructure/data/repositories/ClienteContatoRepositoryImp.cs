namespace cliente_solution.infrastructure.data.repositories;

using System.Collections.Generic;
using cliente_solution.domain.models;
using cliente_solution.domain.repository;
using Microsoft.EntityFrameworkCore;

public class ClienteContatoRepositoryImp : ClienteContatoRepository
{
    private readonly ClienteSolutionContext _context;

    public ClienteContatoRepositoryImp(ClienteSolutionContext context)
    {
        _context = context;
    }

    public int Adicionar(ClienteContato contato)
    {
        _context.ClientesContatos.Add(contato);
        _context.SaveChanges();
        return contato.Id;
    }

    public int Atualizar(ClienteContato contato)
    {
        _context.ClientesContatos.Update(contato);
        _context.SaveChanges();
        return contato.Id;
    }

    public ClienteContato BuscarPorId(int clienteContatoId)
    {
        return _context.ClientesContatos.FirstOrDefault(x => x.Id == clienteContatoId);
    }

    public List<ClienteContato> BuscarTodos(int ClienteId)
    {
        return _context.ClientesContatos.Where(x => x.ClienteId == ClienteId).ToList();
    }

    public bool Remover(int clienteContatoId)
    {
        var contato = BuscarPorId(clienteContatoId);
        _context.ClientesContatos.Remove(contato);
        _context.SaveChanges();
        return true;
    }
}