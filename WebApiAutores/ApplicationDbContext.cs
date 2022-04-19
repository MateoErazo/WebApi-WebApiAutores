using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores
{
    public class ApplicationDbContext : DbContext
    {
     //con este constructor ya se le pueden pasar diferentes configuraciones para Entity Framework
     //como el Connection String
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Autor> Autores { get; set; } 
        public DbSet<Libro> Libros { get; set; } //se pone para poder hacer querys directamente a la tabla de libros
    }
}
