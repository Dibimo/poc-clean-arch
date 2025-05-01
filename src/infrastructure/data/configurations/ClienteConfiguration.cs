using cliente_solution.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cliente_solution.infrastructure.data.configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");

        builder.HasKey(x => x.Id); //definindo a chave primária
        builder.Property(x => x.Id).ValueGeneratedOnAdd();//definindo o auto increment


        //configuramos os campos
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Documento).IsRequired().HasMaxLength(11);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

        //criamos o relacionamento com o ClienteContato

        //note como o código até explica a relação para a gente
        builder.HasMany(cliente => cliente.Contatos) //o cliente tem muitos contatos
            .WithOne(contato => contato.Cliente) //um contato pertence a um cliente
            .HasForeignKey(contato => contato.ClienteId)
            .OnDelete(DeleteBehavior.Cascade); //caso o cliente seja deletado, os contatos também serão

    }
}