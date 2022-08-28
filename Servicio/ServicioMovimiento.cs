using LuisCriolloPrueba.Modelos;
using LuisCriolloPrueba.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Servicio
{
    public class ServicioMovimiento : IServicioMovimiento
    {
        private readonly IRepositorioMovimiento _repositorio;
        public ServicioMovimiento(IRepositorioMovimiento repositorio)
        {
            _repositorio = repositorio;
        }
        Task<List<Movimiento>> IServicioMovimiento.ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        Task<Movimiento> IServicioMovimiento.ObtenerXId(int idCuenta)
        {
            return _repositorio.ObtenerXId(idCuenta);
        }

        public Task<Movimiento> AnadirMovimiento(Movimiento movimiento)
        {
            return _repositorio.AnadirMovimiento(movimiento);
        }

        public Task<Movimiento> ActualizarMovimiento(Movimiento movimiento)
        {
            return _repositorio.ActualizarMovimiento(movimiento);
        }

        void IServicioMovimiento.BorrarMovimiento(int idMovimiento)
        {
            _repositorio.BorrarMovimiento(idMovimiento);
        }

        bool IServicioMovimiento.ExisteMovimiento(int idMovimiento)
        {
            return _repositorio.ExisteMovimiento(idMovimiento);
        }
    }
}
