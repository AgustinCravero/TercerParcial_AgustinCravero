using ClasesTercerParcial.Data;
using ClasesTercerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesTercerParcial.Repositories
{
    public class ProductoRepository
    {
        public static void GuardarProducto(Producto producto)
        {
            using var context = new ApplicationDbContext();
            context.Productos.Add(producto);

            context.SaveChanges();
        }
        public static List<Producto> ObtenerProductos()
        {
            using var context = new ApplicationDbContext();
            return context.Productos.ToList();
        }
    }
}
