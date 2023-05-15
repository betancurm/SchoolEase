using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class DocenteService : IDocenteService
    { 
        SchoolEaseContext context;
        public DocenteService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Docente> Get()
        {
            return context.Docentes;
        }
        public async Task Save(Docente docente)
        {
            context.Docentes.Add(docente);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Docente docente)
        {
            var DocenteActual = context.Docentes.Find(id);
            if (DocenteActual != null)
            {
                DocenteActual.TipoDocumento = docente.TipoDocumento;
                DocenteActual.NumeroDocumento = docente.NumeroDocumento;
                DocenteActual.PrimerNombre = docente.PrimerNombre;
                DocenteActual.SegundoNombre = docente.SegundoNombre;
                DocenteActual.PrimerApellido = docente.PrimerApellido;
                DocenteActual.SegundoApellido = docente.SegundoApellido;
                DocenteActual.Direccion = docente.Direccion;
                DocenteActual.Telefono = docente.Telefono;
                DocenteActual.CorreoElectronico = docente.CorreoElectronico;
                DocenteActual.Celular = docente.Celular;
                DocenteActual.Sexo = docente.Sexo;
                DocenteActual.FechaNacimiento = docente.FechaNacimiento;
                DocenteActual.NivelAcademico = docente.NivelAcademico;
                DocenteActual.Profesion = docente.Profesion;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var DocenteActual = context.Docentes.Find(id);
            if (DocenteActual != null)
            {
                context.Docentes.Remove(DocenteActual);
                await context.SaveChangesAsync();
            }
        }

    }
    public interface IDocenteService
    {
        IEnumerable<Docente> Get();
        Task Save(Docente docente);
        Task Update(int id, Docente docente);
        Task Delete(int id);
    }
}
