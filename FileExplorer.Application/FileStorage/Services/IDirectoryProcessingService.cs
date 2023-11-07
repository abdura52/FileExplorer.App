using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IDirectoryProcessingService
{
    ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, FilterModel filterModel);

}
