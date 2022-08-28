using LuisCriolloPrueba.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Repositorio
{
    public class RepositorioCuenta : IRepositorioCuenta
    {
        private readonly BaseDatosContext _context;

        public RepositorioCuenta(BaseDatosContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Cuenta> ActualizarCuenta(Cuenta Cuenta)
        {
            var result = await _context.Cuenta
                .FirstOrDefaultAsync(e => e.idCuenta == Cuenta.idCuenta);

            if (result != null)
            {
                result.estado = Cuenta.estado;
             //   result.clienteId = Cuenta.clienteId;
                result.numeroCuenta = Cuenta.numeroCuenta;
                result.saldoInicial = Cuenta.saldoInicial;
                result.tipoCuenta = Cuenta.tipoCuenta;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Cuenta> AnadirCuenta(Cuenta Cuenta)
        {
            var result = await _context.Cuenta.AddAsync(Cuenta);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async void BorrarCuenta(int idCuenta)
        {
            var result = await _context.Cuenta
                .FirstOrDefaultAsync(e => e.idCuenta == idCuenta);
            if (result != null)
            {
                _context.Cuenta.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public bool ExisteCuenta(int idCuenta)
        {
            if (_context.Cuenta.Any(e => e.idCuenta == idCuenta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Cuenta>> ObtenerTodos()
        {
            return await _context.Cuenta.ToListAsync();
        }

        public async Task<Cuenta> ObtenerXId(int idCuenta)
        {
            return await _context.Cuenta
                .FirstOrDefaultAsync(e => e.idCuenta == idCuenta);
        }
    }
}
