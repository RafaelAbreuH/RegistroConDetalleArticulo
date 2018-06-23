using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroDetalleArticulo.Entidades
{
    public class Cotizaciones
    {

        [Key]
        public int CotizacionId { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }
        [StringLength(100)]
        public string Comentario { get; set; }

        public virtual ICollection<CotizacionesDetalle> Detalle { get; set; }

        public Cotizaciones()
        {
           
            this.Detalle = new List<CotizacionesDetalle>(); // always initialize the list
        }

        public void AgregarDetalle(int id, int CotizacionId, int PersonaId, int ArticuloId, int Cantidad, int Precio, int Importe)
        {
            this.Detalle.Add(new CotizacionesDetalle(id, CotizacionId, PersonaId, ArticuloId, Cantidad, Precio, Importe));
        }
    }
}
