using System.Net.Http;
using System.Text.Json;

var client = new HttpClient();

HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");

if (response.IsSuccessStatusCode)
{
    string content = await response.Content.ReadAsStringAsync();
    CatFact? catFact = JsonSerializer.Deserialize<CatFact>(content);

    if (catFact is not null)
    {
        Console.WriteLine($"Fact: {catFact.Fact}");
        Console.WriteLine($"Length: {catFact.Length}");
    }
    else
    {
        Console.WriteLine("Error: failed to deserialize the cat fact.");
    }
}
else
{
    Console.WriteLine($"Error: {response.StatusCode}");
}
