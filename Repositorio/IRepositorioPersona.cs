using LuisCriolloPrueba.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Repositorio
{
    public interface IRepositorioPersona
    {
        Task<List<Persona>> ObtenerTodos();
        Task<Persona> ObtenerXId(int idPersona);
        Task<Persona> AnadirPersona(Persona persona);
        Task<Persona> ActualizarPersona(Persona persona);
        void BorrarPersona(int idPersona);
        bool ExistePersona(int idPersona);
    }
}
