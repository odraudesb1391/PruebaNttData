using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Modelos
{
    public class BaseDatosContext : DbContext
    {
        public BaseDatosContext()
        {

        }
        public BaseDatosContext(DbContextOptions<BaseDatosContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<Persona> Persona { get; set; }
      
    }
}
