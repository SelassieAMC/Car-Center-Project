using car_center_project.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace car_center_project.Persistence
{
    public partial class Test_CCenterContext : DbContext
    {
        public Test_CCenterContext()
        {
        }

        public Test_CCenterContext(DbContextOptions<Test_CCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mecanicos> Mecanicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=10.1.6.13;Database=Test_CCenter;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Mecanicos>(entity =>
            {
                entity.HasKey(e => new { e.TipoDocumento, e.Documento })
                    .HasName("mecanicos_pk");

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("tipo_documento")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("primer_apellido")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasColumnName("primer_nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundo_apellido")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("segundo_nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
