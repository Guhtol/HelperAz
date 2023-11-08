using Application.SeedWork;

namespace Infrastructure;
public class ReadJsons : IReadJsons
{
    private string FolderJsons { get; }
    private Dictionary<int, string> FilesPath { get; } = new Dictionary<int, string>();
    public Dictionary<int, string> FilesNames { get; } = new Dictionary<int, string>();
    public ReadJsons()
    {
        FolderJsons = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");
        GetFilesName();
    }

    public string this[int key]
    {
        get
        {
            if (!FilesPath.ContainsKey(key)) return string.Empty;
            return FilesPath[key];
        }
    }

    public async Task<string> RedByKey(int key)
    {
        if (!FilesPath.ContainsKey(key)) return string.Empty;

        return await File.ReadAllTextAsync(FilesPath[key]).ConfigureAwait(false);
    }
    private void GetFilesName()
    {
        int index = 1;
        foreach (string filePath in Directory.EnumerateFiles(FolderJsons))
        {
            FilesPath.Add(index, filePath);
            FilesNames.Add(index,Path.GetFileNameWithoutExtension(filePath));
            index++;
        }
    }
}
