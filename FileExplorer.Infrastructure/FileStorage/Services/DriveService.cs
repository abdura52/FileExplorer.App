using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DriveService : IDriveService
{
    private readonly IDriveBroker _broker;

    public DriveService(IDriveBroker broker)
    {
        _broker = broker;
    }

    public ValueTask<IEnumerable<StorageDrive>> GetAsync()
    {
        var drives = _broker.Get();

        return new ValueTask<IEnumerable<StorageDrive>>(drives);
    }
}
