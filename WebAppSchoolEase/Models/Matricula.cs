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
        public int IdGradoAcademico { get; set; }
        public int IdAcudiente { get; set; }

    }
}
