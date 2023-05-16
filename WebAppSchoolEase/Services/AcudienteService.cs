using System.Net.Http.Json;
using System.Text.Json;
using WebAppSchoolEase.Models;

namespace WebAppSchoolEase.Services
{
    public class AcudienteService: IAcudienteService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;

        public AcudienteService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Acudiente>?> Get()
        {
            var response = await client.GetAsync("api/acudiente");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Acudiente>>(content, options);

        }
        public async Task Add(Acudiente acudiente)
        {
            var response = await client.PostAsync("api/acudiente", JsonContent.Create(acudiente));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
    }



    public interface IAcudienteService
    {
        Task<List<Acudiente>?> Get();
        Task Add(Acudiente acudiente);

    }

}

