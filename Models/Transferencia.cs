using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaZonaVirtual.Models
{
    public class Transferencia
    {
        [Key]
        public string Trans_codigo { get; set; }
        public int Trans_medio_pago { get; set; }
        public int Trans_estado { get; set; }
        public float Trans_total { get; set; }
        public string Trans_fecha { get; set; }
        public string Trans_concepto { get; set; }
    }
}
