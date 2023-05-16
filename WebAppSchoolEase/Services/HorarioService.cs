using WebAppSchoolEase.Models;
using System.Net.Http.Json;
using System.Text.Json;
namespace WebAppSchoolEase.Services
{
    public class HorarioService : IHorarioService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
        public HorarioService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Horario>?> Get()
        {
            var response = await client.GetAsync("api/Horario");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Horario>>(content, options);

        }
        public async Task Add(Horario horario)
        {
            var response = await client.PostAsync("api/Horario", JsonContent.Create(horario));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
    }
    public interface IHorarioService
    {
        Task<List<Horario>?> Get();
        Task Add(Horario horario);
    }
}

