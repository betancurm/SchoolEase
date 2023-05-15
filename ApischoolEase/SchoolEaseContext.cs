using ApischoolEase.Models;
using Microsoft.EntityFrameworkCore;

namespace ApischoolEase
{
    public class SchoolEaseContext : DbContext
    {
        public DbSet<PeriodoAcademico> PeriodosAcademicos { get; set; }
        public DbSet<NivelAcademico> NivelesAcademicos { get; set; }
        public DbSet<JornadaAcademica> JornadasAcademicas { get; set; }
        public DbSet<GradoAcademico> GradosAcademicos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<PlanEstudio> PlanesEstudios { get; set; }
        public DbSet<Acudiente> Acudientes { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        public SchoolEaseContext(DbContextOptions<SchoolEaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Matricula
            List<Matricula> MatriculaInit = new List<Matricula>
            {

            };
            modelBuilder.Entity<Matricula>(matricula =>
            {
                matricula.ToTable("Matricula");
                matricula.HasKey(m => m.IdMatricula);
                matricula.Property(m => m.FechaRegistro).IsRequired();
                matricula.Property(m => m.InstitucionDeProcedencia).HasMaxLength(50);
                matricula.Property(m => m.EsRepitente).IsRequired();
                matricula.Property(m => m.NuevoOAntiguo).IsRequired();
                matricula.Property(m => m.IdEstudiante).IsRequired();
                matricula.Property(m => m.IdGradoAcademico).IsRequired();
                matricula.Property(m => m.IdGrupo).IsRequired();
                matricula.Property(m => m.IdAcudiente).IsRequired();
                matricula.HasOne(m => m.Estudiante).WithMany(e => e.Matriculas).HasForeignKey(m => m.IdEstudiante);
                matricula.HasOne(m => m.GradoAcademico).WithMany(g => g.Matriculas).HasForeignKey(m => m.IdGradoAcademico);
                matricula.HasOne(m => m.Grupo).WithMany(g => g.Matriculas).HasForeignKey(m => m.IdGrupo);
                matricula.HasOne(m => m.Acudiente).WithMany(a => a.Matriculas).HasForeignKey(m => m.IdAcudiente);

                matricula.HasData(MatriculaInit);
            });
            //Acudiente
            List<Acudiente> AcudienteInit = new List<Acudiente>
            {
                new Acudiente(){IdPersona = 2, TipoDocumento = TipoDocumento.CC, NumeroDocumento = "1198765432", PrimerNombre = "María", SegundoNombre = "Isabel", PrimerApellido = "González", SegundoApellido = "Pérez", Direccion = "Carrera 23 # 45-67", Telefono = "2567890", Celular = "3104567890", CorreoElectronico = "mariaigonzalezp@gmail.com", FechaNacimiento = new DateTime(1985, 6, 15), Sexo = Sexo.F, EstadoCivil = EstadoCivil.Soltero, RelacionEstudiante = RelacionEstudiante.Madre},
                new Acudiente(){IdPersona = 3, TipoDocumento = TipoDocumento.CE, NumeroDocumento = "T789012345", PrimerNombre = "José", PrimerApellido = "Sánchez",SegundoApellido ="Cordoba", Direccion = "Calle 10 # 23-45", Telefono = "3456789", Celular = "3156789012", CorreoElectronico = "josesanchez@gmail.com", FechaNacimiento = new DateTime(1978, 2, 8), Sexo = Sexo.M, EstadoCivil = EstadoCivil.Viudo, RelacionEstudiante = RelacionEstudiante.Abuelo},
                new Acudiente(){IdPersona = 4, TipoDocumento = TipoDocumento.PA, NumeroDocumento = "ABCDE12345", PrimerNombre = "Laura", SegundoNombre = "Isabel", PrimerApellido = "Castañeda", SegundoApellido = "Gómez", Direccion = "Calle 31 # 56-78", Telefono = "3668545", Celular = "3012345678", CorreoElectronico = "lauraisabelc@gmail.com", FechaNacimiento = new DateTime(1990, 12, 3), Sexo = Sexo.F, EstadoCivil = EstadoCivil.Soltero, RelacionEstudiante = RelacionEstudiante.Tia},
                new Acudiente(){IdPersona = 5, TipoDocumento = TipoDocumento.TI, NumeroDocumento = "123456789", PrimerNombre = "Juan", SegundoNombre = "Pablo", PrimerApellido = "López", SegundoApellido = "Vargas", Direccion = "Carrera 15 # 30-45", Telefono = "2893456", Celular = "3174567890", CorreoElectronico = "juanplopezv@gmail.com", FechaNacimiento = new DateTime(1975, 8, 12), Sexo = Sexo.M, EstadoCivil = EstadoCivil.Casado, RelacionEstudiante = RelacionEstudiante.Tio},
                new Acudiente(){IdPersona = 6, TipoDocumento = TipoDocumento.CC, NumeroDocumento = "9876543210", PrimerNombre = "Carolina", SegundoNombre = "Isabel", PrimerApellido = "Moreno", SegundoApellido = "García", Direccion = "Carrera 10 # 25-67", Telefono = "3456789", Celular = "3105678901", CorreoElectronico = "carolinamorenog@gmail.com", FechaNacimiento = new DateTime(1982, 4, 25), Sexo = Sexo.F, EstadoCivil = EstadoCivil.Soltero, RelacionEstudiante = RelacionEstudiante.Hermana}
            };
            modelBuilder.Entity<Acudiente>(acudiente =>
            {
                acudiente.ToTable("Acudiente");
                acudiente.HasKey(a => a.IdPersona);
                acudiente.Property(a => a.TipoDocumento).IsRequired();
                acudiente.Property(a => a.NumeroDocumento).IsRequired().HasMaxLength(20);
                acudiente.Property(a => a.PrimerNombre).IsRequired().HasMaxLength(50);
                acudiente.Property(a => a.SegundoNombre).HasMaxLength(50);
                acudiente.Property(a => a.PrimerApellido).IsRequired().HasMaxLength(50);
                acudiente.Property(a => a.SegundoApellido).HasMaxLength(50);
                acudiente.Property(a => a.Direccion).IsRequired().HasMaxLength(100);
                acudiente.Property(a => a.Telefono).HasMaxLength(20);
                acudiente.Property(a => a.Celular).IsRequired().HasMaxLength(20);
                acudiente.Property(a => a.CorreoElectronico).HasMaxLength(50);
                acudiente.Property(a => a.FechaNacimiento).IsRequired();
                acudiente.Property(a => a.Sexo).IsRequired();
                acudiente.Property(a => a.EstadoCivil).IsRequired();
                acudiente.Property(a => a.RelacionEstudiante).IsRequired();
                acudiente.HasData(AcudienteInit);
            });


            //PlanEstudio
            List<PlanEstudio> PlanEstudioInit = new List<PlanEstudio>
            {
                new PlanEstudio(){IdPlanEstudio = 1, Descripcion = "Nota 1", Porcentaje = 0.20M},
                new PlanEstudio(){IdPlanEstudio = 2, Descripcion = "Nota 2", Porcentaje = 0.10M},
                new PlanEstudio(){IdPlanEstudio = 3, Descripcion = "Nota 3", Porcentaje = 0.05M}
            };
            modelBuilder.Entity<PlanEstudio>(planEstudio =>
            {
                planEstudio.ToTable("PlanEstudio");
                planEstudio.HasKey(p => p.IdPlanEstudio);
                planEstudio.Property(p => p.Descripcion).IsRequired().HasMaxLength(50);
                planEstudio.Property(p => p.Porcentaje).IsRequired();
                planEstudio.HasData(PlanEstudioInit);
            });

            //Calificacion
            List<Calificacion> CalificacionInit = new List<Calificacion>
            {

            };
            modelBuilder.Entity<Calificacion>(calificacion =>
            {
                calificacion.ToTable("Calificacion");
                calificacion.HasKey(c => c.IdCalificacion);
                calificacion.Property(c => c.Nota).IsRequired();
                calificacion.HasOne(c => c.Estudiante).WithMany(e => e.Calificaciones).HasForeignKey(c => c.IdEstudiante);
                calificacion.HasOne(c => c.PlanEstudio).WithMany(p => p.Calificaciones).HasForeignKey(c => c.IdPlanEstudio);
                calificacion.HasData(CalificacionInit);
            });
            //Estudiante
            List<Estudiante> EstudianteInit = new List<Estudiante>()
            {
               new Estudiante (){IdPersona = 1, TipoDocumento = TipoDocumento.RC, NumeroDocumento = "1002568777", PrimerNombre = "Maria", SegundoNombre ="Isabel", PrimerApellido= "García", SegundoApellido="López", Direccion = "Carrera 18 # 25-45", Telefono = "6448899", FechaNacimiento=new DateTime(2013, 07, 22), Sexo = Sexo.F},
               new Estudiante (){IdPersona = 2, TipoDocumento = TipoDocumento.TI, NumeroDocumento = "1108456335", PrimerNombre = "Pedro", SegundoNombre ="Antonio", PrimerApellido= "Gómez", SegundoApellido="Ramirez", Direccion = "Avenida 5 # 23-11", Telefono = "3298710", FechaNacimiento=new DateTime(2008, 11, 30), Sexo = Sexo.M},
               new Estudiante (){IdPersona = 3, TipoDocumento = TipoDocumento.RC, NumeroDocumento = "1199887744", PrimerNombre = "Ana", SegundoNombre ="Carolina", PrimerApellido= "Pérez", SegundoApellido="Díaz", Direccion = "Calle 25 # 17-56", Telefono = "7755555", FechaNacimiento=new DateTime(2012, 03, 10), Sexo = Sexo.F},
               new Estudiante (){IdPersona = 4, TipoDocumento = TipoDocumento.TI, NumeroDocumento = "1088665432", PrimerNombre = "Luis", SegundoNombre ="Felipe", PrimerApellido= "García", SegundoApellido="Vargas", Direccion = "Carrera 19 # 31-17", Telefono = "4123456", FechaNacimiento=new DateTime(2010, 09, 08), Sexo = Sexo.M}
            };
            modelBuilder.Entity<Estudiante>(estudiante =>
            {
                estudiante.ToTable("Estudiante");
                estudiante.HasKey(e => e.IdPersona);
                estudiante.Property(d => d.TipoDocumento).IsRequired();
                estudiante.HasIndex(d => d.NumeroDocumento).IsUnique();
                estudiante.Property(d => d.NumeroDocumento).IsRequired().HasMaxLength(20);
                estudiante.Property(d => d.PrimerNombre).IsRequired().HasMaxLength(50);
                estudiante.Property(d => d.SegundoNombre).IsRequired(false).HasMaxLength(50);
                estudiante.Property(d => d.PrimerApellido).IsRequired().HasMaxLength(50);
                estudiante.Property(d => d.SegundoApellido).IsRequired(false).HasMaxLength(50);
                estudiante.Property(d => d.Direccion).IsRequired().HasMaxLength(100);
                estudiante.Property(d => d.Telefono).IsRequired().HasMaxLength(20);
                estudiante.Property(d => d.Celular).IsRequired(false).HasMaxLength(20);
                estudiante.Property(d => d.CorreoElectronico).IsRequired(false).HasMaxLength(50);
                estudiante.Property(d => d.FechaNacimiento).IsRequired();
                estudiante.Property(d => d.Sexo).IsRequired();
                estudiante.HasData(EstudianteInit);
            });
            //Asignacion
            List<Asignacion> AsignacionInit = new List<Asignacion>()
            {
                new Asignacion (){IdAsignacion = 1, IdGrupo = 1, IdAsignatura = 1, IdDocente = 1  , IdHorario= 1},
                new Asignacion (){IdAsignacion = 2, IdGrupo = 1, IdAsignatura = 2, IdDocente = 2  , IdHorario= 2},
                new Asignacion (){IdAsignacion = 3, IdGrupo = 1, IdAsignatura = 3, IdDocente = 3  , IdHorario= 3},
                new Asignacion (){IdAsignacion = 4, IdGrupo = 1, IdAsignatura = 4, IdDocente = 4  , IdHorario= 4},
                new Asignacion (){IdAsignacion = 5, IdGrupo = 1, IdAsignatura = 5, IdDocente = 5  , IdHorario= 5},
                new Asignacion (){IdAsignacion = 6, IdGrupo = 1, IdAsignatura = 6, IdDocente = 6  , IdHorario= 6},
                new Asignacion (){IdAsignacion = 7, IdGrupo = 1, IdAsignatura = 7, IdDocente = 1  , IdHorario= 7},
                new Asignacion (){IdAsignacion = 8, IdGrupo = 1, IdAsignatura = 8, IdDocente = 2  , IdHorario= 8},
                new Asignacion (){IdAsignacion = 9, IdGrupo = 1, IdAsignatura = 9, IdDocente = 3  , IdHorario= 9},
                new Asignacion (){IdAsignacion = 10, IdGrupo = 1, IdAsignatura = 10, IdDocente = 4, IdHorario= 10},
                new Asignacion (){IdAsignacion = 11, IdGrupo = 1, IdAsignatura = 11, IdDocente = 5, IdHorario= 11},

            };
            modelBuilder.Entity<Asignacion>(asignacion =>
            {
                asignacion.ToTable("Asignacion");
                asignacion.HasKey(a => a.IdAsignacion);
                asignacion.Property(a => a.IdAsignatura).IsRequired();
                asignacion.Property(a => a.IdGrupo).IsRequired();
                asignacion.Property(a => a.IdDocente).IsRequired();
                asignacion.HasOne(a => a.Grupo).WithMany(g => g.Asignaciones).HasForeignKey(a => a.IdGrupo);
                asignacion.HasOne(a => a.Asignatura).WithMany(a => a.Asignaciones).HasForeignKey(a => a.IdAsignatura);
                asignacion.HasOne(a => a.Docente).WithMany(d => d.Asignaciones).HasForeignKey(a => a.IdDocente);
                asignacion.HasOne(a => a.Horario).WithMany(h => h.Asignaciones).HasForeignKey(a => a.IdHorario);
                asignacion.HasData(AsignacionInit);
            });
            //Horario
            List<Horario> HorarioInit = new List<Horario>()
            {
                new Horario(){IdHorario=1, HoraInicio= "6:00", HoraFin= "7:00", DiaSemana = DiaSemana.Lunes},
                new Horario(){IdHorario=2, HoraInicio= "7:00", HoraFin= "8:00", DiaSemana = DiaSemana.Lunes},
                new Horario(){IdHorario=3, HoraInicio= "8:00", HoraFin= "9:00", DiaSemana = DiaSemana.Lunes},
                new Horario(){IdHorario=4, HoraInicio= "9:30", HoraFin= "10:30", DiaSemana = DiaSemana.Lunes},
                new Horario(){IdHorario=5, HoraInicio= "10:30", HoraFin= "11:30", DiaSemana = DiaSemana.Lunes},
                new Horario(){IdHorario=6, HoraInicio= "11:30", HoraFin= "12:30", DiaSemana = DiaSemana.Lunes},
                new Horario(){IdHorario=7, HoraInicio= "6:00", HoraFin= "7:00", DiaSemana = DiaSemana.Martes},
                new Horario(){IdHorario=8, HoraInicio= "7:00", HoraFin= "8:00", DiaSemana = DiaSemana.Martes},
                new Horario(){IdHorario=9, HoraInicio= "8:00", HoraFin= "9:00", DiaSemana = DiaSemana.Martes},
                new Horario(){IdHorario=10, HoraInicio= "9:30", HoraFin= "10:30", DiaSemana = DiaSemana.Martes},
                new Horario(){IdHorario=11, HoraInicio= "10:30", HoraFin= "11:30", DiaSemana = DiaSemana.Martes},
                new Horario(){IdHorario=12, HoraInicio= "11:30", HoraFin= "12:30", DiaSemana = DiaSemana.Martes},
                new Horario(){IdHorario=13, HoraInicio= "6:00", HoraFin= "7:00", DiaSemana =     DiaSemana.Miercoles},
                new Horario(){IdHorario=14, HoraInicio= "7:00", HoraFin= "8:00", DiaSemana =     DiaSemana.Miercoles},
                new Horario(){IdHorario=15, HoraInicio= "8:00", HoraFin= "9:00", DiaSemana =     DiaSemana.Miercoles},
                new Horario(){IdHorario=16, HoraInicio= "9:30", HoraFin= "10:30", DiaSemana =    DiaSemana.Miercoles},
                new Horario(){IdHorario=17, HoraInicio= "10:30", HoraFin= "11:30", DiaSemana =   DiaSemana.Miercoles},
                new Horario(){IdHorario=18, HoraInicio= "11:30", HoraFin= "12:30", DiaSemana =   DiaSemana.Miercoles},
                new Horario(){IdHorario=19, HoraInicio= "6:00", HoraFin= "7:00", DiaSemana =     DiaSemana.Jueves},
                new Horario(){IdHorario=20, HoraInicio= "7:00", HoraFin= "8:00", DiaSemana =     DiaSemana.Jueves},
                new Horario(){IdHorario=21, HoraInicio= "8:00", HoraFin= "9:00", DiaSemana =     DiaSemana.Jueves},
                new Horario(){IdHorario=22, HoraInicio= "9:30", HoraFin= "10:30", DiaSemana =    DiaSemana.Jueves},
                new Horario(){IdHorario=23, HoraInicio= "10:30", HoraFin= "11:30", DiaSemana =   DiaSemana.Jueves},
                new Horario(){IdHorario=24, HoraInicio= "11:30", HoraFin= "12:30", DiaSemana =   DiaSemana.Jueves},
                new Horario(){IdHorario=25, HoraInicio= "6:00", HoraFin= "7:00", DiaSemana =     DiaSemana.Viernes},
                new Horario(){IdHorario=26, HoraInicio= "7:00", HoraFin= "8:00", DiaSemana =     DiaSemana.Viernes},
                new Horario(){IdHorario=27, HoraInicio= "8:00", HoraFin= "9:00", DiaSemana =     DiaSemana.Viernes},
                new Horario(){IdHorario=28, HoraInicio= "9:30", HoraFin= "10:30", DiaSemana =    DiaSemana.Viernes},
                new Horario(){IdHorario=29, HoraInicio= "10:30", HoraFin= "11:30", DiaSemana =   DiaSemana.Viernes},
                new Horario(){IdHorario=30, HoraInicio= "11:30", HoraFin= "12:30", DiaSemana =   DiaSemana.Viernes},
            };
            modelBuilder.Entity<Horario>(horario =>
            {
                horario.ToTable("Horario");
                horario.HasKey(h => h.IdHorario);
                horario.Property(h => h.HoraInicio).HasMaxLength(10).IsRequired();
                horario.Property(h => h.HoraFin).HasMaxLength(10).IsRequired();
                horario.Property(h => h.DiaSemana).IsRequired();
                horario.HasData(HorarioInit);
            });
            //Docente
            List<Docente> DocenteInit = new List<Docente>()
            {
                new Docente (){IdPersona = 1, TipoDocumento = TipoDocumento.CC, NumeroDocumento = "1152451870", PrimerNombre = "Juan", SegundoNombre ="Manuel", PrimerApellido= "Betancur", SegundoApellido="Mesa", Direccion = "Calle 31D # 89D 30", Telefono = "5824384",Celular="3053224270", CorreoElectronico="juanb9410@gmail.com", FechaNacimiento=new DateTime(1994, 10, 27), NivelAcademico = tiponivelacademico.Superior, Profesion = "Ingeniero de Sistemas", Sexo = Sexo.M},
                new Docente (){IdPersona = 2, TipoDocumento = TipoDocumento.CC, NumeroDocumento = "1029384756", PrimerNombre = "María", SegundoNombre ="Alejandra", PrimerApellido= "González", SegundoApellido="López", Direccion = "Calle 25 # 55-20", Telefono = "5623748",Celular="3127654321", CorreoElectronico="mariaglz88@hotmail.com", FechaNacimiento=new DateTime(1988, 02, 15), NivelAcademico = tiponivelacademico.Maestria, Profesion = "Licenciada en Ciencias Naturales", Sexo = Sexo.F},
                new Docente (){IdPersona = 3, TipoDocumento = TipoDocumento.TI, NumeroDocumento = "981234567", PrimerNombre = "Pedro", SegundoNombre ="Andrés", PrimerApellido= "Martínez", SegundoApellido="Sánchez", Direccion = "Carrera 10 # 30-15", Telefono = "3754896",Celular="3007654321", CorreoElectronico="pamartinez@gmail.com", FechaNacimiento=new DateTime(1985, 06, 23), NivelAcademico = tiponivelacademico.Maestria, Profesion = "Economista", Sexo = Sexo.M},
                new Docente (){IdPersona = 4, TipoDocumento = TipoDocumento.CC, NumeroDocumento = "1098765432", PrimerNombre = "Lina", SegundoNombre ="Marcela", PrimerApellido= "Ramírez", SegundoApellido="Gómez", Direccion = "Calle 8 # 26-42", Telefono = "4857391",Celular="3149876543", CorreoElectronico="linaramirezg@hotmail.com", FechaNacimiento=new DateTime(1990, 12, 10), NivelAcademico = tiponivelacademico.Maestria, Profesion = "Ingeniera Industrial", Sexo = Sexo.F},
                new Docente (){IdPersona = 5, TipoDocumento = TipoDocumento.CC, NumeroDocumento = "7654321098", PrimerNombre = "David", SegundoNombre ="Santiago", PrimerApellido= "Gómez", SegundoApellido="Londoño", Direccion = "Carrera 7 # 15-10", Telefono = "3579812",Celular="3108765432", CorreoElectronico="davids.gomezl@gmail.com", FechaNacimiento=new DateTime(1982, 05, 04), NivelAcademico = tiponivelacademico.Superior, Profesion = "Licenciado en Matemáticas", Sexo = Sexo.M},
                new Docente (){IdPersona = 6, TipoDocumento = TipoDocumento.CE, NumeroDocumento = "ABCD1234", PrimerNombre = "Marcela", SegundoNombre ="Patricia", PrimerApellido= "Montoya", SegundoApellido="Zapata", Direccion = "Calle 21 # 16-80", Telefono = "2836457",Celular="3012345678", CorreoElectronico="marcelamontoya@hotmail.com", FechaNacimiento=new DateTime(1996, 09, 08), NivelAcademico = tiponivelacademico.Superior, Profesion = "Licenciada en Español", Sexo = Sexo.F}
            };
            modelBuilder.Entity<Docente>(docente =>
            {
                docente.ToTable("Docente");
                docente.HasKey(d => d.IdPersona);
                docente.Property(d => d.TipoDocumento).IsRequired();
                docente.HasIndex(d => d.NumeroDocumento).IsUnique();
                docente.Property(d => d.NumeroDocumento).IsRequired().HasMaxLength(20);
                docente.Property(d => d.PrimerNombre).IsRequired().HasMaxLength(50);
                docente.Property(d => d.SegundoNombre).HasMaxLength(50);
                docente.Property(d => d.PrimerApellido).IsRequired().HasMaxLength(50);
                docente.Property(d => d.SegundoApellido).HasMaxLength(50);
                docente.Property(d => d.Direccion).IsRequired().HasMaxLength(100);
                docente.Property(d => d.Telefono).IsRequired().HasMaxLength(20);
                docente.Property(d => d.Celular).IsRequired().HasMaxLength(20);
                docente.Property(d => d.CorreoElectronico).IsRequired().HasMaxLength(50);
                docente.Property(d => d.FechaNacimiento).IsRequired();
                docente.Property(d => d.NivelAcademico).IsRequired();
                docente.Property(d => d.Profesion).IsRequired().HasMaxLength(50);
                docente.Property(d => d.Sexo).IsRequired();

                docente.HasData(DocenteInit);

            });

            //Asignatura
            List<Asignatura> AsignaturaInit = new List<Asignatura>()
            {
                new Asignatura(){ IdAsignatura = 1, NombreAsignatura = "Matematicas", },
                new Asignatura(){ IdAsignatura = 2, NombreAsignatura = "Español", },
                new Asignatura(){ IdAsignatura = 3, NombreAsignatura = "Ciencias Naturales", },
                new Asignatura(){ IdAsignatura = 4, NombreAsignatura = "Ciencias Sociales", },
                new Asignatura(){ IdAsignatura = 5, NombreAsignatura = "Ingles", },
                new Asignatura(){ IdAsignatura = 6, NombreAsignatura = "Educacion Fisica", },
                new Asignatura(){ IdAsignatura = 7, NombreAsignatura = "Educacion Artistica", },
                new Asignatura(){ IdAsignatura = 8, NombreAsignatura = "Informatica", },
                new Asignatura(){ IdAsignatura = 9, NombreAsignatura = "Formacion Cristiana", },
                new Asignatura(){ IdAsignatura = 10, NombreAsignatura = "Fisica", },
                new Asignatura(){ IdAsignatura = 11, NombreAsignatura = "Quimica", }
            };
            modelBuilder.Entity<Asignatura>(asignatura =>
            {
                asignatura.ToTable("Asignatura");
                asignatura.HasKey(a => a.IdAsignatura);
                asignatura.Property(a => a.NombreAsignatura).IsRequired().HasMaxLength(50);
                asignatura.HasData(AsignaturaInit);

            });

            //Grupo
            List<Grupo> GrupoInit = new List<Grupo>
            {
                new Grupo() { IdGrupo = 1, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.A },
                new Grupo() { IdGrupo = 2, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.B },
                new Grupo() { IdGrupo = 3, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.C },
                new Grupo() { IdGrupo = 4, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.D },
                new Grupo() { IdGrupo = 5, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.E },
                new Grupo() { IdGrupo = 6, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.F },
                new Grupo() { IdGrupo = 7, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.G },
                new Grupo() { IdGrupo = 8, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.H },
                new Grupo() { IdGrupo = 9, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.I },
                new Grupo() { IdGrupo = 10, Vacantes = 30, VacantesDisponibles = 0, VacantesOcupadas = 0, NombreGrupo = GradoSeccion.J },
            };
            modelBuilder.Entity<Grupo>(grupo =>
            {
                grupo.ToTable("Grupo");
                grupo.HasKey(g => g.IdGrupo);
                grupo.Property(g => g.Vacantes).IsRequired();
                grupo.Property(g => g.VacantesDisponibles).IsRequired();
                grupo.Property(g => g.VacantesOcupadas).IsRequired();
                grupo.Property(g => g.NombreGrupo).IsRequired();
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
                new JornadaAcademica() { IdJornadaAcademica = 1, TipoJornadaAcademica = tipoJornadaAcademica.Mañana, HoraInicio = "6:00", HoraFin = "12:30" , IdNivelAcademico = 1 },
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
                new NivelAcademico() { IdNivelAcademico = 4, TipoNivelAcademico = tiponivelacademico.Media, IdPeriodoAcademico = 1, },
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
