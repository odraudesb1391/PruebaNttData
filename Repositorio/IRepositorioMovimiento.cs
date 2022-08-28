using LuisCriolloPrueba.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Repositorio
{
    public interface IRepositorioMovimiento
    {
        Task<List<Movimiento>> ObtenerTodos();
        Task<Movimiento> ObtenerXId(int idPersona);
        Task<Movimiento> AnadirMovimiento(Movimiento movimiento);
        Task<Movimiento> ActualizarMovimiento(Movimiento movimiento);
        void BorrarMovimiento(int idMovimiento);
        bool ExisteMovimiento(int idMovimiento);
    }
}
