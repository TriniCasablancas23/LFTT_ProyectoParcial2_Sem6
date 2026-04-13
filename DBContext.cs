using Microsoft.EntityFrameworkCore;

namespace Proyec_Tienda_musica.Modelos
{
    // Clase de contexto de base de datos que hereda de DbContext.
    // Es el puente principal entre la aplicación y SQL Server mediante EF Core.
    public class DBContext : DbContext
    {
        // Representa la tabla Instrumentos en la base de datos.
        // Permite realizar operaciones CRUD sobre los registros de tipo Tienda.
        public DbSet<Tienda> Instrumentos { get; set; }
        // Constructor que recibe las opciones de configuración del contexto.
        // Es requerido para que la Inyección de Dependencias funcione correctamente
        // al registrar el contexto en Program.cs con AddDbContext.
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        // Método que se ejecuta al crear el modelo de la base de datos.
        // Se usa para configurar propiedades adicionales que no se pueden
        // expresar solo con data annotations en la clase entidad.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Especifica la precisión del campo Precio como decimal(18,2)
            // para evitar advertencias de truncamiento al ejecutar las migraciones.
            modelBuilder.Entity<Tienda>()
                .Property(t => t.Precio)
                .HasColumnType("decimal(18,2)");
        }
    }
}