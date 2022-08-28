using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Modelos
{
    public class Movimiento
    {
     [Key]
        public int idMovimiento { get; set; }
        public int clienteId { get; set; }
        public int idCuenta { get; set; }
        public DateTime fechaMovimiento { get; set; }
        public string tipoMovimiento { get; set; }
        public string numeroCuenta { get; set; }
        public decimal saldoInicial { get; set; }
        public char estado { get; set;  }
        public decimal movimiento { get; set; }
        public decimal saldoDisponible { get; set; }

    }
}
