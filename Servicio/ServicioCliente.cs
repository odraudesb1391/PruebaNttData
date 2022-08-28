using LuisCriolloPrueba.Modelos;
using LuisCriolloPrueba.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Servicio
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IRepositorioCliente _repositorio;
        public ServicioCliente(IRepositorioCliente repositorio)
        {
            _repositorio = repositorio;
        }
        Task<List<Cliente>> IServicioCliente.ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        Task<Cliente> IServicioCliente.ObtenerXId(int clienteId)
        {
            return _repositorio.ObtenerXId(clienteId);
        }

        public Task<Cliente> AnadirCliente(Cliente cliente)
        {
            return _repositorio.AnadirCliente(cliente);
        }

        public Task<Cliente> ActualizarCliente(Cliente cliente)
        {
            return _repositorio.ActualizarCliente(cliente);
        }

        void IServicioCliente.BorrarCliente(int clienteId)
        {
            _repositorio.BorrarCliente(clienteId);
        }

        bool IServicioCliente.ExisteCliente(int clienteId)
        {
            return _repositorio.ExisteCliente(clienteId);
        }
    }
}
