using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaZonaVirtual.Models
{
    public class Usuario
    {
        [Key]
        public string usuario_identificacion { get; set; }
        public string usuario_nombre { get; set; }
        public string usuario_email { get; set; }
    }
}
