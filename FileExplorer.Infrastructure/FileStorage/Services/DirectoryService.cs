using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.Common.Querying.Extensions;
using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _broker;

    public DirectoryService(IDirectoryBroker broker)
    {
        _broker = broker;
    }

    public IEnumerable<StorageDirectory> GetDirectories(string directoryPath, FilterPagination paginationOptions)
        => _broker.GetDirectories(directoryPath).ApplyPagination(paginationOptions);

    public IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions = default)
        => paginationOptions is not null
        ? _broker.GetDirectoriesPath(directoryPath).ApplyPagination(paginationOptions)
        : _broker.GetDirectoriesPath(directoryPath);


    public IEnumerable<StorageFile> GetFiles(string directoryPath, FilterPagination paginationOptions)
    {
        return paginationOptions is not null
            ? _broker.GetFiles(directoryPath).ApplyPagination(paginationOptions)
            : _broker.GetFiles(directoryPath);
    }

    public IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions)
        => _broker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);
}
