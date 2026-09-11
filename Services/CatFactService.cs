using System.Text.Json;

public class CatFactService
{
    private const string ApiUrl = "https://catfact.ninja/fact";
    private readonly HttpClient _httpClient;

    public CatFactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFact?> GetCatFactAsync()
    {
        using HttpResponseMessage response = await _httpClient.GetAsync(ApiUrl);

        response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CatFact>(content);
    }
}
