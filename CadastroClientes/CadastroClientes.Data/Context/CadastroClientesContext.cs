using CadastroClientes.Data.Mapping;
using CadastroClientes.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClientes.Data.Context
{
    public class CadastroClientesContext : DbContext
    {
        public CadastroClientesContext(DbContextOptions<CadastroClientesContext> options) : base(options)
        { }
        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientesMapping());
        }
    }
}
