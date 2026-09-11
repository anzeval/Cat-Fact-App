using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddHttpClient<CatFactService>();
services.AddTransient<FileService>();

using ServiceProvider serviceProvider = services.BuildServiceProvider();

CatFactService catFactService =
    serviceProvider.GetRequiredService<CatFactService>();
FileService fileService =
    serviceProvider.GetRequiredService<FileService>();

try
{
    CatFact? catFact = await catFactService.GetCatFactAsync();

    if (catFact is not null)
    {
        await fileService.SaveCatFactAsync(catFact);

        Console.WriteLine("Fact saved successfully.");
        Console.WriteLine($"Fact: {catFact.Fact}");
        Console.WriteLine($"Length: {catFact.Length}");
    }
    else
    {
        Console.WriteLine("Error: failed to deserialize the cat fact.");
    }
}
catch (HttpRequestException error) when (error.StatusCode is not null)
{
    Console.WriteLine($"Error: {error.StatusCode}");
}
catch (Exception error)
{
    Console.WriteLine(error);
}
