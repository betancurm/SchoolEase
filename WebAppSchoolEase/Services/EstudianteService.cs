using System.Net.Http.Json;
using System.Text.Json;
using WebAppSchoolEase.Models;



namespace WebAppSchoolEase.Services
{
    public class EstudianteService : IEstudianteService
    {

        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
        public EstudianteService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Estudiante>?> Get()
        {
            var response = await client.GetAsync("api/estudiante");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Estudiante>>(content, options);

        }
        public async Task Add(Estudiante estudiante)
        {
            var response = await client.PostAsync("api/estudiante", JsonContent.Create(estudiante));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
    }



    public interface IEstudianteService
    {
        Task<List<Estudiante>?> Get();
        Task Add(Estudiante estudiante);

    }
}
