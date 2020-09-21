using CadastroClientes.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClientes.Data.Mapping
{
    public class ClientesMapping : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.DataNascimento)
                .IsRequired();

            builder.Property(x => x.Sexo)
                .IsRequired();

            builder.ToTable(nameof(Clientes));
        }
    }
}
