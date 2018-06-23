using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroDetalleArticulo.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int CantidadCotizada { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Articulos()
        {

        }


        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
