using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class FileProccessingService : IFileProccessingService   
{
    private readonly IFileService _fileService;
    private readonly IDirectoryService _directoryService;

    public FileProccessingService(IFileService fileService, IDirectoryService directoryService)
    {
        _fileService = fileService;
        _directoryService = directoryService;
    }

    public ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel)
    {
        var filteredFilesPath = _directoryService
            .GetFilesPath(filterModel.DirectoryPath, filterModel)
            .Where(filePath => filterModel.FilesType.Contains(_fileService.GetFileType(filePath)));

        var files = _fileService.GetFilesByPathAsync(filteredFilesPath);

        return files;
    }

    public async ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath)
    {
        var filterPagination = new FilterPagination
        {
            PageSize = int.MaxValue,
            PageToken = 1
        };

        var filesPath = _directoryService.GetFilesPath(directoryPath, filterPagination);
        var files = await _fileService.GetFilesByPathAsync(filesPath);

        var filesSummary = _fileService.GetFilesSummary(files);

        return new StorageFileFilterDataModel
        {
            FilterData = filesSummary.ToList()
        };
    }
}