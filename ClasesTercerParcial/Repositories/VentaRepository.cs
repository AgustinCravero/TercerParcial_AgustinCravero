using ClasesTercerParcial.Data;
using ClasesTercerParcial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesTercerParcial.Repositories
{
    public class VentaRepository
    {
        public static void GuardarVenta(Venta venta)
        {
            using var context = new ApplicationDbContext();
            context.Ventas.Add(venta);

            context.SaveChanges();
        }
        public static List<Venta> ObtenerVentas()
        {
            using var context = new ApplicationDbContext();
            return context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
                .ToList();
        }
    }
}
