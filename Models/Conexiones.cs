
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresa.Models
{
    public class Conexiones : DbContext
    {
        public Conexiones(DbContextOptions<Conexiones> options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; } = null!;
        public DbSet<Proveedores> Proveedores { get; set; } = null!;

        // Definir explícitamente las claves primarias
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedores>()
                .HasKey(p => p.id_proveedor);

            modelBuilder.Entity<Clientes>()
                .HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
