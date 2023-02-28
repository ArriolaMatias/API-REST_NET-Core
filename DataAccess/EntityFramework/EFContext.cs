using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccess.EntityFramework
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            _modelBuilder.Entity<Categoria>().HasKey(cat => cat.Id);

            _modelBuilder.Entity<Subcategoria>().HasOne<Categoria>("CategoriaPadre");

            _modelBuilder.Entity<Movimiento>().HasKey(cat => cat.Id);
            _modelBuilder.Entity<Movimiento>().HasOne<Categoria>("Categoria");
            _modelBuilder.Entity<Movimiento>().HasOne<Subcategoria>("Subcategoria");

            IniciarDatos(_modelBuilder);

        }

        private void IniciarDatos(ModelBuilder _modelBuilder)
        {
            Categoria c1 = new Categoria() { Id = 1, Nombre = "OCIO", Detalle = "Movimientos relacionados con actividades de entretenimiento" };
            Categoria c2 = new Categoria() { Id = 2, Nombre = "AUTO", Detalle = "Movimientos relacionados con el mantenimiento del auto" };
            Categoria c3 = new Categoria() { Id = 3, Nombre = "SALUD", Detalle = "Movimientos relacionados con mi salud" };
            Categoria c4 = new Categoria() { Id = 4, Nombre = "TEST", Detalle = "Movimientos relacionados con testing" };
            _modelBuilder.Entity<Categoria>().HasData(c1, c2, c3, c4);
        }

    }
}