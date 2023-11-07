using FileExplorer.Application.Common.Models.Filtering;

namespace FileExplorer.Application.FileStorage.Models.Filtering;

public class StorageFileFilterModel : FilterPagination
{
    public string DirectoryPath { get; set; } = String.Empty;

    public ICollection<StorageFileType> FilesType { get; set; } = default;
}