using System.Net.Http;

var client = new HttpClient();

HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");

if (response.IsSuccessStatusCode)
{
    string content = await response.Content.ReadAsStringAsync();
    Console.WriteLine(content);
}
else
{
    Console.WriteLine($"Error: {response.StatusCode}");
}
