using LuisCriolloPrueba.Modelos;
using LuisCriolloPrueba.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Servicio
{
    public class ServicioPersona : IServicioPersona
    {
        private readonly IRepositorioPersona _repositorio;
        public ServicioPersona(IRepositorioPersona repositorio)
        {
            _repositorio = repositorio;
        }
        Task<List<Persona>> IServicioPersona.ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        Task<Persona> IServicioPersona.ObtenerXId(int idCuenta)
        {
            return _repositorio.ObtenerXId(idCuenta);
        }

        public Task<Persona> AnadirPersona(Persona persona)
        {
            return _repositorio.AnadirPersona(persona);
        }

        public Task<Persona> ActualizarPersona(Persona persona)
        {
            return _repositorio.ActualizarPersona(persona);
        }

        void IServicioPersona.BorrarPersona(int idPersona)
        {
            _repositorio.BorrarPersona(idPersona);
        }

        bool IServicioPersona.ExistePersona(int idPersona)
        {
            return _repositorio.ExistePersona(idPersona);
        }
    }
}
