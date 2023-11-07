using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Application.FileStorage.Brokers;

public interface IFileBroker
{
    StorageFile GetByPath(string path);
}