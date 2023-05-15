using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class EstudianteService : IEstudianteService
    {
        SchoolEaseContext context;
        public EstudianteService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Estudiante> Get()
        {
            return context.Estudiantes;
        }
        public async Task Save(Estudiante estudiante)
        {
            context.Estudiantes.Add(estudiante);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Estudiante estudiante)
        {
            var EstudianteActual = context.Estudiantes.Find(id);
            if (EstudianteActual != null)
            {
                EstudianteActual.TipoDocumento = estudiante.TipoDocumento;
                EstudianteActual.NumeroDocumento = estudiante.NumeroDocumento;
                EstudianteActual.PrimerNombre = estudiante.PrimerNombre;
                EstudianteActual.SegundoNombre = estudiante.SegundoNombre;
                EstudianteActual.PrimerApellido = estudiante.PrimerApellido;
                EstudianteActual.SegundoApellido = estudiante.SegundoApellido;
                EstudianteActual.Direccion = estudiante.Direccion;
                EstudianteActual.Telefono = estudiante.Telefono;
                EstudianteActual.CorreoElectronico = estudiante.CorreoElectronico;
                EstudianteActual.Celular = estudiante.Celular;
                EstudianteActual.Sexo = estudiante.Sexo;
                EstudianteActual.FechaNacimiento = estudiante.FechaNacimiento;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var EstudianteActual = context.Estudiantes.Find(id);
            if (EstudianteActual != null)
            {
                context.Estudiantes.Remove(EstudianteActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IEstudianteService
    {
        IEnumerable<Estudiante> Get();
        Task Save(Estudiante estudiante);
        Task Update(int id, Estudiante estudiante);
        Task Delete(int id);
    }
}
