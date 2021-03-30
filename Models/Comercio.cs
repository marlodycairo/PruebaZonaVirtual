using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaZonaVirtual.Models
{
    public class Comercio
    {
        [Key]
        public int Comercio_codigo { get; set; }
        public string Comercio_nombre { get; set; }
        public string Comercio_nit { get; set; }
        public string Comercio_direccion { get; set; }
    }
}
