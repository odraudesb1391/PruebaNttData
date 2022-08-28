using LuisCriolloPrueba.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Servicio
{
    public interface IServicioMovimiento
    {
        Task<List<Movimiento>> ObtenerTodos();
        Task<Movimiento> ObtenerXId(int idMovimiento);
        Task<Movimiento> AnadirMovimiento(Movimiento movimiento);
        Task<Movimiento> ActualizarMovimiento(Movimiento movimiento);
        void BorrarMovimiento(int idMovimiento);
        bool ExisteMovimiento(int idMovimiento);
    }
}
