using LuisCriolloPrueba.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Servicio
{
    public interface IServicioCliente
    {
        Task<List<Cliente>> ObtenerTodos();
        Task<Cliente> ObtenerXId(int clienteId);
        Task<Cliente> AnadirCliente(Cliente cliente);
        Task<Cliente> ActualizarCliente(Cliente cliente);
        void BorrarCliente(int clienteId);
        bool ExisteCliente(int clienteId);
    }
}
