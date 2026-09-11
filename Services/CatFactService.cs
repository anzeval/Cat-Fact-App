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
        try
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(ApiUrl);

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CatFact>(content);
        }
        catch (HttpRequestException)
        {
            return null;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
