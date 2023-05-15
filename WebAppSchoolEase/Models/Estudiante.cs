namespace WebAppSchoolEase.Models
{
    public class Estudiante
    {

        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
        public string celular { get; set; }
        public int tipoDocumento { get; set; }
        public int sexo { get; set; }
        public DateTime fechadenacimiento { get; set; }
    }


}
