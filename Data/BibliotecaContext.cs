using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() : base("name=BibliotecaContext")
        {
        }

        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Evitar que EF pluralice los nombres de las tablas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
