public class FileService
{
    private const string FileName = "catfacts.txt";

    public async Task SaveCatFactAsync(CatFact catFact)
    {
        string line = $"Fact: {catFact.Fact} | Length: {catFact.Length}";

        await File.AppendAllTextAsync(FileName, line + Environment.NewLine);
    }
}
