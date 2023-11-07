namespace FileExplorer.Application.FileStorage.Models.Settings;

public class FileFilterSettings
{
    public ICollection<ExtensionSettings> FileExtensions { get; set; } = default;
}