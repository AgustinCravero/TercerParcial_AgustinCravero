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
    public class EmpleadoRepository
    {
        public static void CargarEmpleado(Empleado empleado)
        {
            using var context = new ApplicationDbContext();
            context.Empleados.Add(empleado);

            context.SaveChanges();
        }
        public static List<Empleado> ObtenerEmpleados()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.ToList();
        }
        public static void EliminarEmpleado(Empleado empleado)
        {
            using var context = new ApplicationDbContext();
            context.Empleados.Remove(empleado);

            context.SaveChanges();
        }
    }
}
