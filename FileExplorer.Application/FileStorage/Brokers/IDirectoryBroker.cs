using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Brokers;

public interface IDirectoryBroker
{
    IEnumerable<string> GetDirectoriesPath(string path);

    IEnumerable<string> GetFilesPath(string path);

    IEnumerable<StorageDirectory> GetDirectories(string path);

    IEnumerable<StorageFile> GetFiles(string path);
}
