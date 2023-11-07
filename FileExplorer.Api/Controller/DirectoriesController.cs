using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    private readonly IDirectoryProcessingService _directoryProcessingService;

    public DirectoriesController(IDirectoryProcessingService directoryProcessingService)
    {
        _directoryProcessingService = directoryProcessingService;
    }

    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetEntries(
        [FromQuery] FilterModel filterModel,
        [FromServices] IWebHostEnvironment environment)
    {
        var result = await _directoryProcessingService.GetEntriesAsync(environment.WebRootPath, filterModel);
        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{directoryPath}/entries")]
    public async ValueTask<IActionResult> GetSubdirectoryEntires([FromRoute] string directoryPath, [FromQuery] FilterModel filterModel)
    {
        var result = await _directoryProcessingService.GetEntriesAsync(directoryPath, filterModel);

        return result.Any() ? Ok(result) : NoContent();
    }
}
