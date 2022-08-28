using LuisCriolloPrueba.Modelos;
using LuisCriolloPrueba.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Servicio
{
    public class ServicioCuenta : IServicioCuenta
    {
        private readonly IRepositorioCuenta _repositorio;
        public ServicioCuenta(IRepositorioCuenta repositorio)
        {
            _repositorio = repositorio;
        }
        Task<List<Cuenta>> IServicioCuenta.ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        Task<Cuenta> IServicioCuenta.ObtenerXId(int idCuenta)
        {
            return _repositorio.ObtenerXId(idCuenta);
        }

        public Task<Cuenta> AnadirCuenta(Cuenta cuenta)
        {
            return _repositorio.AnadirCuenta(cuenta);
        }

        public Task<Cuenta> ActualizarCuenta(Cuenta cuenta)
        {
            return _repositorio.ActualizarCuenta(cuenta);
        }

        void IServicioCuenta.BorrarCuenta(int idCuenta)
        {
            _repositorio.BorrarCuenta(idCuenta);
        }

        bool IServicioCuenta.ExisteCuenta(int idCuenta)
        {
            return _repositorio.ExisteCuenta(idCuenta);
        }
    }
}
