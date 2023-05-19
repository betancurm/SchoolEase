using System.Net.Http.Json;
using System.Text.Json;
using WebAppSchoolEase.Models;

namespace WebAppSchoolEase.Services
{
    public class  GradoAcademicoService : IGradoAcademicoService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;

        public GradoAcademicoService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<GradoAcademico>?> Get()
        {
            var response = await client.GetAsync("api/gradoacademico");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<GradoAcademico>>(content, options);

        }
        public async Task Add(GradoAcademico gradoAcademico)
        {
            var response = await client.PostAsync("api/gradoacademico", JsonContent.Create(gradoAcademico));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Delete(int id)
        {
            var response = await client.DeleteAsync($"api/gradoacademico/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Update(GradoAcademico gradoAcademico)
        {
            var response = await client.PutAsync($"api/gradoacademico/{gradoAcademico.IdGradoAcademico}", JsonContent.Create(gradoAcademico));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

    }
    public interface IGradoAcademicoService
    {
        Task<List<GradoAcademico>?> Get();
        Task Add(GradoAcademico gradoAcademico);
        Task Delete(int id);
        Task Update(GradoAcademico grado);
    }

}

