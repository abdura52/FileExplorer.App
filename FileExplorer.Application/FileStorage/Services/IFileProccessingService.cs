using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IFileProccessingService
{
    ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath);

    ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel);
}