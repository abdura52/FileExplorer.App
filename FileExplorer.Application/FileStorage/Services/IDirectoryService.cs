using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IDirectoryService
{
    IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions = default);

    IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions);

    IEnumerable<StorageDirectory> GetDirectories(string directoryPath, FilterPagination paginationOptions = default);

    IEnumerable<StorageFile> GetFiles(string directoryPath, FilterPagination paginationOptions = default);
}
