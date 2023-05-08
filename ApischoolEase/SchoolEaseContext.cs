using ApischoolEase.Models;
using Microsoft.EntityFrameworkCore;

namespace ApischoolEase
{
    public class SchoolEaseContext :DbContext
    {
        public DbSet<PeriodoAcademico> PeriodosAcademicos { get; set; }
        public DbSet<NivelAcademico> NivelesAcademicos { get; set; }
        public DbSet<JornadaAcademica> JornadasAcademicas { get; set; }
        public DbSet<GradoAcademico> GradosAcademicos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }

        public SchoolEaseContext(DbContextOptions<SchoolEaseContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Grupo
            List<Grupo> GrupoInit = new List<Grupo>
            { 
                new Grupo() { IdGrupo = 1, Vacantes = 30, VacantesDisponibles = 30, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.A, IdGradoAcademico = 1 },
                new Grupo() { IdGrupo = 2, Vacantes = 30, VacantesDisponibles = 30 , VacantesOcupadas = 0, NombreGrupo = GradoSeccion.B, IdGradoAcademico = 2 },
                new Grupo() { IdGrupo = 3, Vacantes = 30, VacantesDisponibles = 30 , VacantesOcupadas = 0, NombreGrupo = GradoSeccion.C, IdGradoAcademico = 2 }
            };
            modelBuilder.Entity<Grupo>(grupo =>
            {
                grupo.ToTable("Grupo");
                grupo.HasKey(g => g.IdGrupo);
                grupo.Property(g => g.Vacantes).IsRequired();
                grupo.Property(g => g.VacantesDisponibles).IsRequired();
                grupo.Property(g => g.VacantesOcupadas).IsRequired();
                grupo.Property(g => g.NombreGrupo).IsRequired();
                grupo.Property(g => g.IdGradoAcademico).IsRequired();
                grupo.HasOne(g => g.GradoAcademico).WithMany(g => g.Grupos).HasForeignKey(g => g.IdGradoAcademico);
                grupo.HasData(GrupoInit);
            });
            //Grado Academico
            List<GradoAcademico> GradoAcademicoInit = new List<GradoAcademico>
            {
                new GradoAcademico() { IdGradoAcademico = 1, Descripcion = "Primero", IdNivelAcademico = 1 },
                new GradoAcademico() { IdGradoAcademico = 2, Descripcion = "Segundo", IdNivelAcademico = 1 },
            };
            modelBuilder.Entity<GradoAcademico>(gradoAcademico =>
            {
                gradoAcademico.ToTable("GradoAcademico");
                gradoAcademico.HasKey(g => g.IdGradoAcademico);
                gradoAcademico.Property(g => g.Descripcion).IsRequired().HasMaxLength(50);
                gradoAcademico.Property(g => g.IdNivelAcademico).IsRequired();
                gradoAcademico.HasOne(g => g.NivelAcademico).WithMany(n => n.GradosAcademicos).HasForeignKey(g => g.IdNivelAcademico);
                gradoAcademico.HasData(GradoAcademicoInit);
            });
            //Jornada Academica
            List<JornadaAcademica> JornadaAcademicaInit = new List<JornadaAcademica>
            {
                new JornadaAcademica() { IdJornadaAcademica = 1, TipoJornadaAcademica = tipoJornadaAcademica.Mañana, HoraInicio = "6:30", HoraFin = "12:30" , IdNivelAcademico = 1 },
                new JornadaAcademica() { IdJornadaAcademica = 2, TipoJornadaAcademica = tipoJornadaAcademica.Tarde, HoraInicio = "12:30", HoraFin = "18:30", IdNivelAcademico = 1 }
            };
            modelBuilder.Entity<JornadaAcademica>(jornadaAcademica =>
            {
                jornadaAcademica.ToTable("JornadaAcademica");
                jornadaAcademica.HasKey(j => j.IdJornadaAcademica);
                jornadaAcademica.Property(j => j.TipoJornadaAcademica).IsRequired();
                jornadaAcademica.Property(j => j.HoraInicio).IsRequired();
                jornadaAcademica.Property(j => j.HoraFin).IsRequired();
                jornadaAcademica.Property(j => j.IdNivelAcademico).IsRequired();
                jornadaAcademica.HasOne(j => j.NivelAcademico).WithMany(n => n.JornadasAcademicas).HasForeignKey(j => j.IdNivelAcademico);
                jornadaAcademica.HasData(JornadaAcademicaInit);
            });

            //Nivel Academico
            List<NivelAcademico> nivelAcademicoInit = new List<NivelAcademico>
            {
                new NivelAcademico() { IdNivelAcademico = 1, TipoNivelAcademico = tiponivelacademico.Preescolar, IdPeriodoAcademico = 1, },
                new NivelAcademico() { IdNivelAcademico = 2,TipoNivelAcademico = tiponivelacademico.Primaria, IdPeriodoAcademico = 1, },
                new NivelAcademico() { IdNivelAcademico = 3, TipoNivelAcademico = tiponivelacademico.Secundaria, IdPeriodoAcademico = 1, },
                new NivelAcademico() { IdNivelAcademico = 4, TipoNivelAcademico = tiponivelacademico.Media, IdPeriodoAcademico = 1, }
            };

            modelBuilder.Entity<NivelAcademico>(nivelAcademico =>
            {
                nivelAcademico.ToTable("NivelAcademico");
                nivelAcademico.HasKey(n => n.IdNivelAcademico);
                nivelAcademico.HasOne(n => n.PeriodoAcademico).WithMany(p => p.NivelesAcademicos).HasForeignKey(n => n.IdPeriodoAcademico);
                nivelAcademico.Property(n => n.TipoNivelAcademico).IsRequired();
                nivelAcademico.Property(n => n.IdPeriodoAcademico).IsRequired();
                nivelAcademico.HasData(nivelAcademicoInit);
            });
//-----------------------------------------------------------------------------------------------
            //Periodo Academico
            List<PeriodoAcademico> periodoAcademicoInit = new List<PeriodoAcademico> 
            { 
                new PeriodoAcademico(){ IdPeriodoAcademico = 1, Nombre = "Periodo 2020", FechaInicio = new DateTime(2020, 1, 13), FechaFin = new DateTime(2020, 11, 20), TipoPeriodo = 0},
                new PeriodoAcademico() {IdPeriodoAcademico= 2, Nombre = "Periodo 2021", FechaInicio = new DateTime(2021, 1, 13), FechaFin = new DateTime(2021, 11, 20), TipoPeriodo = 0}
            };
            
            modelBuilder.Entity<PeriodoAcademico>(periodoAcademico =>
            {
                periodoAcademico.ToTable("PeriodoAcademico");
                periodoAcademico.HasKey(p => p.IdPeriodoAcademico);
                periodoAcademico.Property(p => p.Nombre).IsRequired().HasMaxLength(20);
                periodoAcademico.Property(p => p.FechaInicio).IsRequired();
                periodoAcademico.Property(p => p.FechaFin).IsRequired();
                periodoAcademico.Property(p => p.TipoPeriodo).IsRequired();
                periodoAcademico.HasData(periodoAcademicoInit);
            });
        }
    }
}
