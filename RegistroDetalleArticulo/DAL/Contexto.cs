using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroDetalleArticulo.Entidades;
using System.Data.Entity;

namespace RegistroDetalleArticulo.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Cotizaciones> Cotizaciones { get; set; }

        public Contexto() : base("ConStr") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
