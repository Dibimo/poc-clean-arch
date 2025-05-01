using Microsoft.EntityFrameworkCore;

namespace cliente_solution.infrastructure;

public class ClienteSolutionContext : DbContext
{
    public ClienteSolutionContext(DbContextOptions<ClienteSolutionContext> options) : base(options) { }

}