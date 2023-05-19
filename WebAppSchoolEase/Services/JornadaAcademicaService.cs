using System.Net.Http.Json;
using System.Text.Json;
using WebAppSchoolEase.Models;

namespace WebAppSchoolEase.Services
{
    public class JornadaAcademicaService : IJornadaAcademicaService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
        public JornadaAcademicaService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<JornadaAcademica>?> Get()
        {
            var response = await client.GetAsync("api/JornadaAcademica");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<JornadaAcademica>>(content, options);

        }
        public async Task Add(JornadaAcademica jornadaAcademica)
        {
            var response = await client.PostAsync("api/JornadaAcademica", JsonContent.Create(jornadaAcademica));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Delete(int id)
        {
            var response = await client.DeleteAsync($"api/JornadaAcademica/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Update(JornadaAcademica jornadaAcademica)
        {
            var response = await client.PutAsync($"api/JornadaAcademica/{jornadaAcademica.IdJornadaAcademica}", JsonContent.Create(jornadaAcademica));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

    }

    public interface IJornadaAcademicaService
    {
        Task<List<JornadaAcademica>?> Get();
        Task Add(JornadaAcademica jornadaAcademica);
        Task Delete(int id);
        Task Update(JornadaAcademica jornada);
    }
}
