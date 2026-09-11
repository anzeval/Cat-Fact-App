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

bool isSaved = await fileService.SaveCatFactAsync(catFact);

if (!isSaved)
{
    Console.WriteLine("Failed to save the cat fact.");
    return;
}

Console.WriteLine($"Fact: {catFact.Fact}");
Console.WriteLine($"Length: {catFact.Length}");
Console.WriteLine("Saved to catfacts.txt");
