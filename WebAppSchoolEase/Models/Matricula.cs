namespace WebAppSchoolEase.Models
{
    public class Matricula
    {
        public int IdMatricula { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string InstitucionDeProcedencia { get; set; }
        public bool EsRepitente { get; set; }
        public bool NuevoOAntiguo { get; set; }
        public int IdEstudiante { get; set; }
        public Estudiante? Estudiante { get; set; }
        public GradoAcademico? GradoAcademico { get; set; }
        public Acudiente? Acudiente { get; set; }

    }
}
