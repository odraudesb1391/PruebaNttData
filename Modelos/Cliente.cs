using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Modelos
{
    public class Cliente
    {
        [Key]
        public int clienteId { get; set; }
        public int idPersona { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set; }
    }
}
