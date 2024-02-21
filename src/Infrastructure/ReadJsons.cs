using Application.SeedWork;

namespace Infrastructure;
public class ReadJsons : IReadJsons
{
    private string FolderJsons { get; }
    private Dictionary<int, string> FilesPath { get; } = [];
    public Dictionary<int, string> FilesNames { get; } = [];
    public ReadJsons()
    {
        FolderJsons = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");
        GetFilesName();
    }

    public string this[int key]
    {
        get
        {
            if (!FilesPath.TryGetValue(key, out string? value)) return string.Empty;
            return value;
        }
    }

    public async Task<string> RedByKey(int key)
    {
        if (!FilesPath.TryGetValue(key, out string? value)) return string.Empty;

        return await File.ReadAllTextAsync(value).ConfigureAwait(false);
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
