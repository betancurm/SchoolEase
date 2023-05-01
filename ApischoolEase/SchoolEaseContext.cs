using ApischoolEase.Models;
using Microsoft.EntityFrameworkCore;

namespace ApischoolEase
{
    public class SchoolEaseContext :DbContext
    {
        public DbSet<PeriodoAcademico> PeriodosAcademicos { get; set; }
        public SchoolEaseContext(DbContextOptions<SchoolEaseContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<PeriodoAcademico> periodoAcademicosInit = new List<PeriodoAcademico>();
            periodoAcademicosInit.Add(new PeriodoAcademico()
            {
                IdPeriodoAcademico = 1,
                Nombre = "Periodo 2020",
                FechaInicio = new DateTime(2020, 1, 13),
                FechaFin = new DateTime(2020, 11, 20),
                TipoPeriodo = "Calendario A"
            });
            modelBuilder.Entity<PeriodoAcademico>(periodoAcademico =>
            {
                periodoAcademico.ToTable("PeriodoAcademico");
                periodoAcademico.HasKey(p => p.IdPeriodoAcademico);
                periodoAcademico.Property(p => p.Nombre).IsRequired().HasMaxLength(10);
                periodoAcademico.Property(p => p.FechaInicio).IsRequired();
                periodoAcademico.Property(p => p.FechaFin).IsRequired();
                periodoAcademico.Property(p => p.TipoPeriodo).IsRequired();
                periodoAcademico.HasData(periodoAcademicosInit);
            });
        }
    }
}
