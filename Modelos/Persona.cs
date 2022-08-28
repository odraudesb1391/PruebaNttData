using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Modelos
{
    public class Persona
    {
        [Key]
        public int idPersona { get; set; }

        public string nombre { get; set; }
        public char genero { get; set; }
        public int edad { get; set; }
        public string identificacion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }
}
