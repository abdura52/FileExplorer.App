using AutoMapper;
using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class DriveBroker : IDriveBroker
{
    private readonly IMapper _mapper;

    public DriveBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<StorageDrive> Get()
        => DriveInfo.GetDrives().Select(driveInfo => _mapper.Map<StorageDrive>(driveInfo));
}
