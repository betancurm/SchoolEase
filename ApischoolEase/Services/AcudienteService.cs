using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class AcudienteService : IAcudienteService
    {
        SchoolEaseContext context;
        public AcudienteService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Acudiente> Get()
        {
            return context.Acudientes;
        }
        public async Task Save(Acudiente acudiente)
        {
            context.Acudientes.Add(acudiente);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Acudiente acudiente)
        {
            var AcudienteActual = context.Acudientes.Find(id);
            if (AcudienteActual != null)
            {
                AcudienteActual.TipoDocumento = acudiente.TipoDocumento;
                AcudienteActual.NumeroDocumento = acudiente.NumeroDocumento;
                AcudienteActual.PrimerNombre = acudiente.PrimerNombre;
                AcudienteActual.SegundoNombre = acudiente.SegundoNombre;
                AcudienteActual.PrimerApellido = acudiente.PrimerApellido;
                AcudienteActual.SegundoApellido = acudiente.SegundoApellido;
                AcudienteActual.Direccion = acudiente.Direccion;
                AcudienteActual.Telefono = acudiente.Telefono;
                AcudienteActual.CorreoElectronico = acudiente.CorreoElectronico;
                AcudienteActual.Celular = acudiente.Celular;
                AcudienteActual.Sexo = acudiente.Sexo;
                AcudienteActual.FechaNacimiento = acudiente.FechaNacimiento;
                AcudienteActual.EstadoCivil = acudiente.EstadoCivil;
                AcudienteActual.RelacionEstudiante = acudiente.RelacionEstudiante;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var AcudienteActual = context.Acudientes.Find(id);
            if (AcudienteActual != null)
            {
                context.Acudientes.Remove(AcudienteActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IAcudienteService
    {
        IEnumerable<Acudiente> Get();
        Task Save(Acudiente acudiente);
        Task Update(int id, Acudiente acudiente);
        Task Delete(int id);
    }
}
