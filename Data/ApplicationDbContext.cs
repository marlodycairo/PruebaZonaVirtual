using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaZonaVirtual.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaZonaVirtual.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comercio> Comercio { get; set; }
        public DbSet<Transferencia> Transferencia { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        ///public DbSet<HttpClientModel> HttpClientsModels { get; set; }

        //protected internal virtual void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    if (modelBuilder != null)
        //    {
        //        modelBuilder.Entity<Comercio>()
        //                    .HasKey(com => new { com.comercio_codigo, com.comercio_nombre, com.comercio_nit, com.comercio_direccion });

        //        modelBuilder.Entity<Transferencia>()
        //                    .HasKey(tran => new { tran.Trans_codigo, tran.Trans_medio_pago, tran.Trans_estado, tran.Trans_total, tran.Trans_fecha, tran.Trans_concepto });

        //        modelBuilder.Entity<Usuario>()
        //                    .HasKey(usu => new { usu.usuario_identificacion, usu.usuario_nombre, usu.usuario_email });

        //        //modelBuilder.Entity<HttpClientModel>()
        //        //            .HasKey(cli => new { cli.comercio_codigo, cli.comercio_nombre, cli.comercio_nit, cli.comercio_direccion, cli.Trans_codigo, cli.Trans_medio_pago, cli.Trans_estado, cli.Trans_total, cli.Trans_fecha, cli.Trans_concepto, cli.usuario_identificacion, cli.usuario_nombre, cli.usuario_email });
        //    }

        //}

        //[Keyless]
        // public class HttpClientModel
        // {
        //    [NotMapped]
        //     public int comercio_codigo { get; set; }
        //     public string comercio_nombre { get; set; }
        //     public string comercio_nit { get; set; }
        //     public string comercio_direccion { get; set; }
        //     public string Trans_codigo { get; set; }
        //     public int Trans_medio_pago { get; set; }
        //     public int Trans_estado { get; set; }
        //     public float Trans_total { get; set; }
        //     public string Trans_fecha { get; set; }
        //     public string Trans_concepto { get; set; }
        //     public string usuario_identificacion { get; set; }
        //     public string usuario_nombre { get; set; }
        //     public string usuario_email { get; set; }
        // }
    }
}
