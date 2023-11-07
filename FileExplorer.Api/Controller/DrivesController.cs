using AutoMapper;
using FileExplorer.Api.Models.Dtos;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class DrivesController : ControllerBase
{
    private readonly IDriveService _driveService;
    private readonly IMapper _mapper;

    public DrivesController(IDriveService driveService, IMapper mapper)
    {
        _driveService = driveService;
        _mapper = mapper;
    }

    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var data = await _driveService.GetAsync();
        var result = _mapper.Map<IEnumerable<StorageDriveDto>>(data);

        return result.Any() ? Ok(result) : NoContent();
    }
}
