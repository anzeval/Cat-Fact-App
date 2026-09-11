using System.Net.Http;
using System.Text.Json;

var client = new HttpClient();

try
{
    HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");

    if (response.IsSuccessStatusCode)
    {
        string content = await response.Content.ReadAsStringAsync();
        CatFact? catFact = JsonSerializer.Deserialize<CatFact>(content);

        if (catFact is not null)
        {
            string fileName = "catfacts.txt";
            string line = $"Fact: {catFact.Fact} | Length: {catFact.Length}";

            await File.AppendAllTextAsync(fileName, line + Environment.NewLine);

            Console.WriteLine("Fact saved successfully.");
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
}
catch (Exception error)
{
    Console.WriteLine(error);
}
