using FileExplorer.Application.FileStorage.Models.Filtering;

namespace FileExplorer.Application.FileStorage.Models.Settings;

public class ExtensionSettings
{
    public StorageFileType FileType { get; set; }

    public string DisplayName { get; set; } = String.Empty;

    public string ImageUrl { get; set; } = String.Empty;

    public ICollection<string> Extensions { get; set; } = default;
}