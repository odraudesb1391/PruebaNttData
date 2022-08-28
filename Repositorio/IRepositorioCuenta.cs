using LuisCriolloPrueba.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Repositorio
{
    public interface IRepositorioCuenta
    {
        Task<List<Cuenta>> ObtenerTodos();
        Task<Cuenta> ObtenerXId(int idCuenta);
        Task<Cuenta> AnadirCuenta(Cuenta Cuenta);
        Task<Cuenta> ActualizarCuenta(Cuenta Cuenta);
        void BorrarCuenta(int idCuenta);
        bool ExisteCuenta(int idCuenta);
    }
}
