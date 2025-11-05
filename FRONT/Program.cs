using ClasesTercerParcial.Models;
using ClasesTercerParcial.Repositories;

namespace FRONT
{
    internal class Program
    {
        public static List<Empleado> empleados = EmpleadoRepository.ObtenerEmpleados();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menú");
                Console.WriteLine();
                Console.WriteLine("1- ");
                Console.WriteLine("2- ");
                Console.WriteLine("3- ");
                Console.WriteLine("4- ");
                Console.WriteLine("5- ");
                Console.WriteLine("6- Salir");
                Console.WriteLine();
                Console.WriteLine("Ingrese el número correspondiente a la opción");
                string opcion = Console.ReadLine().Trim();
                switch (opcion)
                {
                    case "1":
                        Console.Clear(); 

                        Console.ReadKey(true);
                        break;
                    case "2":
                        Console.Clear();

                        Console.ReadKey(true);
                        break;
                    case "3":
                        Console.Clear();

                        Console.ReadKey(true);
                        break;
                    case "4":
                        Console.Clear();

                        Console.ReadKey(true);
                        break;
                    case "5":
                        Console.Clear();

                        Console.ReadKey(true);
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        Console.ReadKey(true);
                        break;
                }
                if (opcion == "6") break; 
            }
        }
    }
}