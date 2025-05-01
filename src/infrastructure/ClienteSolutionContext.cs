using cliente_solution.domain.models;
using cliente_solution.infrastructure.data.configurations;
using Microsoft.EntityFrameworkCore;

namespace cliente_solution.infrastructure;

public class ClienteSolutionContext : DbContext
{
    public ClienteSolutionContext(DbContextOptions<ClienteSolutionContext> options) : base(options) { }

    //nesse ponto, o que estamos acostumados a fazer é algo como isso:
    public DbSet<Cliente> Clientes { get; set; } //-> criei a tabela de cliente
    public DbSet<ClienteContato> ClientesContatos { get; set; } //-> criei a tabela de contato do cliente

    //a partir daqui, rodamos o comando, Add-Migration e depois o Update-Database e pronto. Nosso banco está configurado.

    //mas, se notar bem, nossas classes de dominio não possuem os atributos de chave primária.
    //a ClienteContato mesmo, nem se quer possui um vinculo com a Cliente.
    //então se rodar os comandos, verá que ocorrem vários erros.

    //o que precisamos fazer então é ensinar ao EF o que ele precisa fazer. O nome desse padrão é "padrão fluente".

    //primeiramente, vamos precisar atualizar a classe Cliente e a ClienteContato, para que elas se relacionem corretamente, o que é feito de forma diferente de como estamos acostumados a fazer.
    //agora acesse os arquivos nessa ordem:

    //src/domain/models/Cliente.cs
    //src/domain/models/ClienteContato.cs

    //adicionamos as propriedades de navegação e vinculos das entidades, mas sem utilizar o Data Annotation de Foreign Key.

    //agora acesse os arquivos de configuração:

    //src/infrastructure/data/configurations/ClienteConfiguration.cs
    //src/infrastructure/data/configurations/ClienteContatoConfiguration.cs

    //agora que "ensinamos" ao EF a maneira de como nosso banco deve funcionar, chamamos a função OnModelCreating:

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new ClienteContatoConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    //agora podemos IMPlementar as interfaces de ClienteRepository e ClienteContatoRepository

    //src/infrastructure/repositories/ClienteRepository.cs
    //src/infrastructure/repositories/ClienteContatoRepository.cs

    //e rodar os comandos Add-Migration e Update-Database.

    //depois de resover as dependências, dos repositories, podemos rodar o nossa aplicação normalmente

    //e pronto. a configuração base já está pronta. Agora podemos ir evoluindo a nossa aplicação com segurança


}