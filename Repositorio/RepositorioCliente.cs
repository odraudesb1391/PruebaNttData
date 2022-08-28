using LuisCriolloPrueba.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly BaseDatosContext _context;

        public RepositorioCliente(BaseDatosContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Cliente> ActualizarCliente(Cliente cliente)
        {
            var result = await _context.Cliente
                .FirstOrDefaultAsync(e => e.clienteId == cliente.clienteId);

            if (result != null)
            {
                result.idPersona = cliente.idPersona;
                result.contrasena = cliente.contrasena;
                result.estado = cliente.estado;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Cliente> AnadirCliente(Cliente cliente)
        {
            var result = await _context.Cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async void BorrarCliente(int clienteId)
        {
            var result = await _context.Cliente
                .FirstOrDefaultAsync(e => e.clienteId == clienteId);
            if (result != null)
            {
                _context.Cliente.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public bool ExisteCliente(int clienteId)
        {
            if (_context.Cliente.Any(e => e.clienteId == clienteId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Cliente>> ObtenerTodos()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> ObtenerXId(int ClienteId)
        {
            return await _context.Cliente
                .FirstOrDefaultAsync(e => e.clienteId == ClienteId);
        }
    }
}
