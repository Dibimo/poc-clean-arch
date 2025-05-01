using cliente_solution.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cliente_solution.infrastructure.data.configurations;

public class ClienteContatoConfiguration : IEntityTypeConfiguration<ClienteContato>
{
    public void Configure(EntityTypeBuilder<ClienteContato> builder)
    {
        builder.ToTable("ClientesContatos");

        builder.HasKey(x => x.Id); //definindo a chave primária
        builder.Property(x => x.Id).ValueGeneratedOnAdd(); //definindo o auto increment


        //configuramos os campos
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Telefone).IsRequired().HasMaxLength(11);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

        builder.Property(x => x.ClienteId).IsRequired();
    }
}