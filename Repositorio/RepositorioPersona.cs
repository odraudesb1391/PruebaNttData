using LuisCriolloPrueba.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Repositorio
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly BaseDatosContext _context;

        public RepositorioPersona(BaseDatosContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Persona> ActualizarPersona(Persona persona)
        {
            var result = await _context.Persona
                .FirstOrDefaultAsync(e => e.idPersona == persona.idPersona);

            if (result != null)
            {
                result.direccion = persona.direccion;
                result.edad = persona.edad;
                result.genero = persona.genero;
                result.identificacion = persona.identificacion;
                result.nombre = persona.nombre;
                result.telefono = persona.telefono;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Persona> AnadirPersona(Persona persona)
        {
            var result = await _context.Persona.AddAsync(persona);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async void BorrarPersona(int idPersona)
        {
            var result = await _context.Persona
                .FirstOrDefaultAsync(e => e.idPersona == idPersona);
            if (result != null)
            {
                _context.Persona.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public bool ExistePersona(int idPersona)
        {
            if (_context.Persona.Any(e => e.idPersona == idPersona))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Persona>> ObtenerTodos()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task<Persona> ObtenerXId(int idPersona)
        {
            return await _context.Persona
                .FirstOrDefaultAsync(e => e.idPersona == idPersona);
        }
    }
}
