public class FileService
{
    private const string FileName = "catfacts.txt";

    public async Task<bool> SaveCatFactAsync(CatFact catFact)
    {
        string line = $"Fact: {catFact.Fact} | Length: {catFact.Length}";

        try
        {
            await File.AppendAllTextAsync(FileName, line + Environment.NewLine);
            return true;
        }
        catch (IOException)
        {
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            return false;
        }
    }
}
