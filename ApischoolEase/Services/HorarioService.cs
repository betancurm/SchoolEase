using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class HorarioService : IHorarioService
    {
        SchoolEaseContext context;
        public HorarioService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Horario> Get()
        {
            return context.Horarios;
        }
        public async Task Save(Horario horario)
        {
            context.Horarios.Add(horario);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Horario horario)
        {
            var HorarioActual = context.Horarios.Find(id);
            if (HorarioActual != null)
            {
                HorarioActual.HoraInicio = horario.HoraInicio;
                HorarioActual.HoraFin = horario.HoraFin;
                HorarioActual.DiaSemana = horario.DiaSemana;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var HorarioActual = context.Horarios.Find(id);
            if (HorarioActual != null)
            {
                context.Horarios.Remove(HorarioActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IHorarioService
    {
        IEnumerable<Horario> Get();
        Task Save(Horario horario);
        Task Update(int id, Horario horario);
        Task Delete(int id);
    }
}
