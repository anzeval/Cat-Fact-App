using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddHttpClient<CatFactService>();
services.AddTransient<FileService>();

using ServiceProvider serviceProvider = services.BuildServiceProvider();

CatFactService catFactService =
    serviceProvider.GetRequiredService<CatFactService>();
FileService fileService =
    serviceProvider.GetRequiredService<FileService>();

CatFact? catFact = await catFactService.GetCatFactAsync();

if (catFact is null)
{
    Console.WriteLine("Failed to get the cat fact.");
    return;
}

await fileService.SaveCatFactAsync(catFact);

Console.WriteLine($"Fact: {catFact.Fact}");
Console.WriteLine($"Length: {catFact.Length}");
Console.WriteLine("Saved to catfacts.txt");
