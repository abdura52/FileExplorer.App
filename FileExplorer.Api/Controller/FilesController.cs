using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private IWebHostEnvironment _environment;
    private IFileProccessingService _fileProccessingService;

    public FilesController(IFileProccessingService fileProccessingService, IWebHostEnvironment webHostEnvironment)
    {
        _fileProccessingService = fileProccessingService;
        _environment = webHostEnvironment;
    }

    [HttpGet("root/files/filter")]
    public async ValueTask<IActionResult> GetFilteredFiles()
    {
        var result = await _fileProccessingService.GetFilterDataModelAsync(_environment.WebRootPath);

        return Ok(result);
    }

    [HttpGet("root/files/by-filter")]
    public async ValueTask<IActionResult> GetFilesByFilter([FromQuery] StorageFileFilterModel filterModel)
    {
        filterModel.DirectoryPath = _environment.WebRootPath;

        var files = await _fileProccessingService.GetByFilterAsync(filterModel);

        return files.Any() ? Ok(files) : NotFound(files);
    }

}