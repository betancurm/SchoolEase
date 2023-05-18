using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class MatriculaService : IMatriculaService
    {
        SchoolEaseContext context;
        public MatriculaService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Matricula> Get()
        {
            return context.Matriculas;
        }
        public async Task Save(Matricula matricula)
        {
            context.Add(matricula);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Matricula matricula)
        {
            var matriculaActual = context.Matriculas.Find(id);
            if (matriculaActual != null)
            {
                matriculaActual.FechaRegistro = matricula.FechaRegistro;
                matriculaActual.InstitucionDeProcedencia = matricula.InstitucionDeProcedencia;
                matriculaActual.EsRepitente = matricula.EsRepitente;
                matriculaActual.NuevoOAntiguo = matricula.NuevoOAntiguo;
                matriculaActual.IdEstudiante = matricula.IdEstudiante;
                matriculaActual.IdGradoAcademico = matricula.IdGradoAcademico;
                matriculaActual.IdAcudiente = matricula.IdAcudiente;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var matricula = context.Matriculas.Find(id);
            if (matricula != null)
            {
                context.Remove(matricula);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IMatriculaService
    {
        IEnumerable<Matricula> Get();
        Task Save(Matricula matricula);
        Task Update(int id, Matricula matricula);
        Task Delete(int id);
    }
}
