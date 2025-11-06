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
    public class ClienteRepository
    {
        public static void GuardarCliente(Cliente cliente)
        {
            using var context = new ApplicationDbContext();
            context.Clientes.Add(cliente);

            context.SaveChanges();
        }
        public static List<Cliente> ObtenerClientes()
        {
            using var context = new ApplicationDbContext();
            return context.Clientes.ToList();
        }
    }
}
