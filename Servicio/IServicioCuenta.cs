using LuisCriolloPrueba.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Servicio
{
    public interface IServicioCuenta
    {
        Task<List<Cuenta>> ObtenerTodos();
        Task<Cuenta> ObtenerXId(int idCuenta);
        Task<Cuenta> AnadirCuenta(Cuenta cuenta);
        Task<Cuenta> ActualizarCuenta(Cuenta cuenta);
        void BorrarCuenta(int idCuenta);
        bool ExisteCuenta(int idCuenta);
    }
}
