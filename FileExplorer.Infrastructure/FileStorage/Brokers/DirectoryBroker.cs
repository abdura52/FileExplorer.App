using AutoMapper;
using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class DirectoryBroker : IDirectoryBroker
{
    private readonly IMapper _mapper;

    public DirectoryBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<StorageDirectory> GetDirectories(string path)
        => _mapper.Map<List<StorageDirectory>>(new DirectoryInfo(path).GetDirectories());

    public IEnumerable<string> GetDirectoriesPath(string path)
        => Directory.GetDirectories(path);

    public IEnumerable<StorageFile> GetFiles(string path)
        => _mapper.Map<List<StorageFile>>(new DirectoryInfo(path).GetFiles());

    public IEnumerable<string> GetFilesPath(string path)
        => Directory.GetFiles(path);
}
