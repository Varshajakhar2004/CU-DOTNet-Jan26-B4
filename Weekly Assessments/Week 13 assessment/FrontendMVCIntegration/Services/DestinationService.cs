using FrontendMVCIntegration.Services;
using System.Net.Http.Json;
using FrontendMVCIntegration.Models;

public class DestinationService : IDestinationService
{
    //private readonly HttpClient _client;
    private readonly HttpClient _httpClient;

    public DestinationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Destination>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Destination>>("api/Destinations");
    }

    public async Task AddAsync(Destination destination)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Destinations", destination);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("API failed: " + response.StatusCode);
        }
    }
}