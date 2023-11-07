using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Settings;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.Extensions.Options;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class FileService : IFileService
{
    private readonly IFileBroker _fileBroker;
    private readonly FileStorageSettings _fileStorageSettings;
    private readonly FileFilterSettings _fileFilterSettings;

    public FileService(IFileBroker fileBroker,
        IOptions<FileStorageSettings> fileStorageSettings,
        IOptions<FileFilterSettings> fileFilterSettings)
    {
        _fileBroker = fileBroker;
        _fileStorageSettings = fileStorageSettings.Value;
        _fileFilterSettings = fileFilterSettings.Value;
    }

    public ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
        => new(filesPath.Select(path => _fileBroker.GetByPath(path)).ToList());

    public ValueTask<StorageFile> GetFileByPathAsync(string filePath)
        => new(_fileBroker.GetByPath(filePath));

    public IEnumerable<StorageFileSummary> GetFilesSummary(IEnumerable<StorageFile> files)
    {
        var filesType = files.Select(file => (File: file, Type: GetFileType(file.Path)));

        return filesType.GroupBy(file => file.Type)
            .Select(filesGroup => new StorageFileSummary
            {
                FileType = filesGroup.Key,
                DisplayName = _fileFilterSettings.FileExtensions
                                  .FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.DisplayName ??
                              "Other files",
                Count = filesGroup.Count(),
                Size = filesGroup.Sum(file => file.File.Size),
                ImageUrl = _fileFilterSettings.FileExtensions
                               .FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.ImageUrl ??
                           _fileStorageSettings.FileImageUrl
            });
    }

    public StorageFileType GetFileType(string filePath)
    {
        var fileExtension = Path.GetExtension(filePath).TrimStart('.');
        var mathedFileType =
            _fileFilterSettings.FileExtensions.FirstOrDefault(e => e.Extensions.Contains(fileExtension));
        return mathedFileType?.FileType ?? StorageFileType.Other;
    }
}