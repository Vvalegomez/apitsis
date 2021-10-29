using apiGestores.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Fabricantes> Fabricantes { get; set; }
        public DbSet<Impuestos> Impuestos { get; set; }
        public DbSet<ProductoRepa> ProductoRepa { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Reparaciones> Reparaciones { get; set; }
        public DbSet<Reportes> Reportes { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


    }
}
