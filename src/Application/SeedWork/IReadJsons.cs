namespace Application.SeedWork;
public interface IReadJsons
{
    string this[int key] { get; }
    Dictionary<int, string> FilesNames { get; }
    Task<string> RedByKey(int key);
}
