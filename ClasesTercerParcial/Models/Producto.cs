using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesTercerParcial.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public List<DetalleVenta> detalleVentas { get; set; } = new List<DetalleVenta>();
        public Producto() { }
    }
}
