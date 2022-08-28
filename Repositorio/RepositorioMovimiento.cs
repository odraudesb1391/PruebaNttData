using LuisCriolloPrueba.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Repositorio
{
    public class RepositorioMovimiento : IRepositorioMovimiento
    {
        private readonly BaseDatosContext _context;
        private readonly IRepositorioCuenta _repositorio;
        public RepositorioMovimiento(BaseDatosContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Movimiento> ActualizarMovimiento(Movimiento movimiento)
        {
            var result = await _context.Movimiento
                .FirstOrDefaultAsync(e => e.idMovimiento == movimiento.idMovimiento);

            if (result != null)
            {
                result.clienteId = movimiento.clienteId;
                result.tipoMovimiento = movimiento.tipoMovimiento;
                result.estado = movimiento.estado;
                result.fechaMovimiento = movimiento.fechaMovimiento;
                result.idCuenta = movimiento.idCuenta;
                result.movimiento = movimiento.movimiento;
                result.numeroCuenta = movimiento.numeroCuenta;
                result.saldoDisponible = movimiento.saldoDisponible;
                result.saldoInicial = movimiento.saldoInicial;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Movimiento> AnadirMovimiento(Movimiento movimiento)
        {
         var saldoInicial = _context.Cuenta
                .Where(e => e.idCuenta == movimiento.idCuenta).Select(x => x.saldoInicial);


            var resultCuenta = await _context.Cuenta
                .FirstOrDefaultAsync(e => e.idCuenta == movimiento.idCuenta);

            if (resultCuenta != null)
            {
                if (resultCuenta.saldoInicial == 0)
                    throw new Exception("Saldo en la cuenta no permite su transaccion");
                resultCuenta.estado = "A";
                resultCuenta.saldoInicial = movimiento.tipoMovimiento == "Credito" 
                    ? resultCuenta.saldoInicial + movimiento.movimiento
                    : resultCuenta.saldoInicial - movimiento.movimiento;

                movimiento.saldoDisponible = resultCuenta.saldoInicial;

            }

            var result = await _context.Movimiento.AddAsync(movimiento);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async void BorrarMovimiento(int idMovimiento)
        {
            var result = await _context.Movimiento
                .FirstOrDefaultAsync(e => e.idMovimiento == idMovimiento);
            if (result != null)
            {
                _context.Movimiento.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public bool ExisteMovimiento(int idPersona)
        {
            if (_context.Movimiento.Any(e => e.idMovimiento == idPersona))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Movimiento>> ObtenerTodos()
        {
            return await _context.Movimiento.ToListAsync();
        }

        public async Task<Movimiento> ObtenerXId(int idMovimiento)
        {
            return await _context.Movimiento
                .FirstOrDefaultAsync(e => e.idMovimiento == idMovimiento);
        }
    }
}
