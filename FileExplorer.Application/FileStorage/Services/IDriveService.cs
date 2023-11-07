using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Services;

public interface IDriveService
{
    ValueTask<IEnumerable<StorageDrive>> GetAsync();
}
