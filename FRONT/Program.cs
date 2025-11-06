using ClasesTercerParcial.Models;
using ClasesTercerParcial.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FRONT
{
    internal class Program
    {
        public static List<Cliente> clientes = ClienteRepository.ObtenerClientes();
        public static List<Producto> productos = ProductoRepository.ObtenerProductos();
        public static List<Venta> ventas = VentaRepository.ObtenerVentas();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menú");
                Console.WriteLine();
                Console.WriteLine("1- Registrar nuevo producto");
                Console.WriteLine("2- Registrar nuevo cliente");
                Console.WriteLine("3- Registrar nueva venta");
                Console.WriteLine("4- Reporte de ventas por cliente");
                Console.WriteLine("5- Salir");
                Console.WriteLine();
                Console.WriteLine("Ingrese el número correspondiente a la opción");
                string opcion = Console.ReadLine().Trim();
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre del Producto");
                        string nombreProducto; 
                        while (true)
                        {
                            nombreProducto = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(nombreProducto) && !NombreProductoValido(nombreProducto)) break;
                            else Console.WriteLine("Ingrese el nombre nuevamente"); 
                        }
                        Console.WriteLine("Ingrese el precio del producto");
                        double precioProducto;
                        while (true)
                        {
                            if (double.TryParse(Console.ReadLine(), out precioProducto) && precioProducto >= 0) break;
                            else Console.WriteLine("Ingrese un precio válido");
                        }
                        Producto nuevoProducto = new Producto
                        {
                            Nombre = nombreProducto,
                            Precio = precioProducto
                        };
                        ProductoRepository.GuardarProducto(nuevoProducto);
                        productos.Add(nuevoProducto);
                        Console.WriteLine("Producto guardado exitosamente");
                        Console.ReadKey(true);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre del cliente: ");
                        string nombreCliente;
                        while (true)
                        {
                            nombreCliente = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(nombreCliente)) break;
                            else Console.WriteLine("Ingrese el nombre nuevamente: ");
                        }
                        Cliente nuevoCliente = new Cliente
                        {
                            Nombre = nombreCliente
                        };
                        ClienteRepository.GuardarCliente(nuevoCliente);
                        clientes.Add(nuevoCliente);
                        Console.WriteLine("Cliente guardado exitosamente");
                        Console.ReadKey(true);
                        break;
                    case "3":
                        Console.Clear();
                        if (!clientes.Any() || !productos.Any())
                        {
                            Console.WriteLine("Debe haber al menos un cliente y un producto registrado.");
                            Console.ReadKey(true);
                            break;
                        }
                        Console.WriteLine("Seleccione el Id del cliente");
                        foreach (Cliente cliente in clientes)
                        {
                            Console.WriteLine($"Id: {cliente.Id} - Nombre: {cliente.Nombre}");
                        }
                        int idClienteSeleccionado;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out idClienteSeleccionado) &&
                                clientes.Any(c => c.Id == idClienteSeleccionado)) break;
                            else Console.WriteLine("Id inválido. Ingrese nuevamente.");
                        }
                        Venta venta = new Venta
                        {
                            ClienteId = idClienteSeleccionado,
                            Fecha = DateTime.Now
                        };
                        while (true)
                        {
                            Console.WriteLine("Ingrese el Id del producto (0 para finalizar)");
                            foreach (var producto in productos)
                            {
                                Console.WriteLine($"Id: {producto.Id} - Nombre: {producto.Nombre} - Precio: {producto.Precio}");
                            }
                            int idProductoSeleccionado;
                            while (true)
                            {
                                if (int.TryParse(Console.ReadLine(), out idProductoSeleccionado) &&
                                    (idProductoSeleccionado == 0 || productos.Any(p => p.Id == idProductoSeleccionado))) break;
                                else Console.WriteLine("Id inválido. Ingrese nuevamente.");
                            }
                            if (idProductoSeleccionado == 0) break;
                            Console.WriteLine("Ingrese la cantidad");
                            int cantidad; 
                            while (true)
                            {
                                if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0) break;
                                else Console.WriteLine("Cantidad inválida. Ingrese nuevamente.");
                            }
                            Producto productoSeleccionado = productos.First(p => p.Id == idProductoSeleccionado);
                            DetalleVenta detalle = new DetalleVenta
                            {
                                ProductoId = idProductoSeleccionado,
                                Cantidad = cantidad,
                                Subtotal = productoSeleccionado.Precio * cantidad
                            };
                            venta.Detalles.Add(detalle);
                        }
                        if (!venta.Detalles.Any())
                        {
                            Console.WriteLine("No se agregó ningún producto. Venta cancelada.");
                            Console.ReadKey(true);
                            break;
                        }
                        venta.Total = venta.Detalles.Sum(d => d.Subtotal);
                        VentaRepository.GuardarVenta(venta);
                        ventas.Add(venta);
                        Console.WriteLine("Venta registrada exitosamente");
                        Console.Clear(); 
                        Console.ReadKey(true);
                        break;
                    case "4":
                        Console.Clear();
                        if (!ventas.Any())
                        {
                            Console.WriteLine("No hay ventas registradas.");
                            Console.ReadKey(true);
                            break;
                        }
                        var grupos = ventas.GroupBy(v => v.ClienteId);

                        foreach (var grupo in grupos)
                        {
                            var cliente = grupo.First().Cliente;

                            Console.WriteLine($"Cliente: {cliente.Nombre} - Id: {cliente.Id}");

                            foreach (var ventaCliente in grupo)
                            {
                                Console.WriteLine($"Venta Id {ventaCliente.Id} - Fecha: {ventaCliente.Fecha} - Total: ${ventaCliente.Total}");
                                foreach (var detalle in ventaCliente.Detalles)
                                {
                                    Console.WriteLine($"Producto: {detalle.Producto.Nombre} - Cantidad: {detalle.Cantidad} - Subtotal ${detalle.Subtotal}");
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.ReadKey(true);
                        break;
                    case "5": 
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        Console.ReadKey(true);
                        break;
                }
                if (opcion == "5") break; 
            }
        }
        public static bool NombreProductoValido(string nombreProducto)
        {
            return productos.Exists(p => p.Nombre.ToLower().Trim() == nombreProducto.ToLower().Trim());   
        }
    }
}