
namespace Chatbot.Data
{
    public class DataContext : DbContext
    {
        // Implementar tabla a la base de datos
        public DbSet<PreguntaRespuesta> PreguntaRespuestas { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Entidad a la que se va a configurar al generar el modelo para la ejecucion
            builder.Entity<PreguntaRespuesta>(x =>
            {
                // Cambia el nombre de la tabla en la base de datos pero no en la solicion del proyecto
                x.ToTable("pregunta_respuesta");

                x.Property(y => y.Id).HasColumnName("pregunta_respuesta_ID");
            });
        }
    }
}
