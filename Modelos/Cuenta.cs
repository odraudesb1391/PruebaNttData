using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Modelos
{
    public class Cuenta
    {
       [Key]
        public int idCuenta { get; set; }
        public int clienteId { get; set; }

        public string numeroCuenta { get; set; }
        public string tipoCuenta { get; set; }
        public decimal saldoInicial { get; set; }
        public string estado { get; set; }
    }
}
