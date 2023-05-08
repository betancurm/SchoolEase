using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class GradoAcademicoService : IGradoAcademicoService
    {
        SchoolEaseContext context;
        public GradoAcademicoService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<GradoAcademico> Get()
        {
            return context.GradosAcademicos;
        }
        public async Task Save(GradoAcademico gradoAcademico)
        {
            context.GradosAcademicos.Add(gradoAcademico);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, GradoAcademico gradoAcademico)
        {
            var GradoActual = context.GradosAcademicos.Find(id);
            if (GradoActual != null)
            {
                GradoActual.Descripcion = gradoAcademico.Descripcion;
                GradoActual.IdNivelAcademico = gradoAcademico.IdNivelAcademico;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var GradoActual = context.GradosAcademicos.Find(id);
            if (GradoActual != null)
            {
                context.GradosAcademicos.Remove(GradoActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IGradoAcademicoService
    {
        IEnumerable<GradoAcademico> Get();
        Task Save(GradoAcademico gradoAcademico);
        Task Update(int id, GradoAcademico gradoAcademico);
        Task Delete(int id);
    }
}
