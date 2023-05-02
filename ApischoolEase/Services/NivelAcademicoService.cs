using ApischoolEase.Models;
using System.Threading;

namespace ApischoolEase.Services
{
    public class NivelAcademicoService: INivelAcademicoService
    {
        SchoolEaseContext context;
        public NivelAcademicoService(SchoolEaseContext dbcontext)
        {
             context= dbcontext;
        }
        public IEnumerable<NivelAcademico> Get()
        {
            return context.NivelesAcademicos;
        }
        public async Task Save(NivelAcademico nivelAcademico)
        {
            context.Add(nivelAcademico);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, NivelAcademico nivelAcademico)
        {
         var NivelAcademicoActual = context.NivelesAcademicos.Find(id);
            if (NivelAcademicoActual!=null)
            {
                NivelAcademicoActual.IdPeriodoAcademico = nivelAcademico.IdPeriodoAcademico;
                NivelAcademicoActual.TipoNivelAcademico = nivelAcademico.TipoNivelAcademico;
                NivelAcademicoActual.IdPeriodoAcademico = nivelAcademico.IdPeriodoAcademico;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var NivelAcademicoActual = context.NivelesAcademicos.Find(id);
            if (NivelAcademicoActual!=null)
            {
                context.Remove(NivelAcademicoActual);
                await context.SaveChangesAsync();
            }
        }

    }
    public interface INivelAcademicoService
    {
        IEnumerable<NivelAcademico> Get();
        Task Save(NivelAcademico nivelAcademico);
        Task Update(int id, NivelAcademico nivelAcademico);
        Task Delete(int id);
    }
}
