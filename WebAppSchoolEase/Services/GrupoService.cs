using WebAppSchoolEase.Models;
using System.Net.Http.Json;
using System.Text.Json;
namespace WebAppSchoolEase.Services
{
    public class GrupoService : IGrupoService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
        public GrupoService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Grupo>?> Get()
        {
            var response = await client.GetAsync("api/Grupo");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Grupo>>(content, options);

        }
        public async Task Add(Grupo grupo)
        {
            var response = await client.PostAsync("api/Grupo", JsonContent.Create(grupo));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Delete(int id)
        {
            var response = await client.DeleteAsync($"api/Grupo/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Update(Grupo grupo)
        {
            var response = await client.PutAsync($"api/Asignatura/{grupo.IdGrupo}", JsonContent.Create(grupo));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

    }
    public interface IGrupoService
    {
        Task<List<Grupo>?> Get();
        Task Add(Grupo grupo);
        Task Delete(int id);
        Task Update(Grupo grupo);
    }
}

