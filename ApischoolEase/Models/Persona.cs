namespace ApischoolEase.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Celular { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
    public enum TipoDocumento
    {
        CC, TI, CE, PA, RC
    }
    public enum Sexo
    {
        M, F
    }
}
