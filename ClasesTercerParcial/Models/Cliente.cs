using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesTercerParcial.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Venta> Ventas { get; set; } = new List<Venta>();
        public Cliente() { }
        
    }
}
