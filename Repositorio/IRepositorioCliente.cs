using LuisCriolloPrueba.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Repositorio
{
    public interface IRepositorioCliente
    {
        Task<List<Cliente>> ObtenerTodos();
        Task<Cliente> ObtenerXId(int ClienteId);
        Task<Cliente> AnadirCliente(Cliente cliente);
        Task<Cliente> ActualizarCliente(Cliente cliente);
        void BorrarCliente(int clienteId);
        bool ExisteCliente(int clienteId);
    }
}
