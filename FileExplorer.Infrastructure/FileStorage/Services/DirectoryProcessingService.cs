using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Services;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryProcessingService : IDirectoryProcessingService
{
    private readonly IDirectoryService _directoryService;

    public DirectoryProcessingService(IDirectoryService directoryService, IFileService fileService)
    {
        _directoryService = directoryService;
    }

    public ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, FilterModel filterModel)
    {
        var entries = new List<IStorageEntry>();

        if (filterModel.IncludeDirectories)
            entries.AddRange(_directoryService.GetDirectories(directoryPath, filterModel));

        if (filterModel.IncludeFiles)
            entries.AddRange(_directoryService.GetFiles(directoryPath, filterModel));

        return new ValueTask<List<IStorageEntry>>(entries);
    }
}
