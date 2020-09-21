using CadastroClientes.Data.Context;
using CadastroClientes.Domain.Interfaces.Repository;
using CadastroClientes.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CadastroClientes.Data.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly CadastroClientesContext _context;
        public ClientesRepository(CadastroClientesContext context)
        {
            _context = context;
        }

        public Clientes AddClientes(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            _context.SaveChanges();
            return clientes;
        }

        public IEnumerable<Clientes> GetAllClientes()
        {
            return _context.Clientes.AsEnumerable().OrderBy(x => x.Id);
        }

        public void ExcluirClientes(int id)
        {
            var cliente = _context.Clientes.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public void UpdateClientes(Clientes cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Clientes GetById(int id)
        {
            return _context.Clientes.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
