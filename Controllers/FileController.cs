using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;

namespace Controllers;

[ApiController, Route("file")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FileRequest request)
    {
        var result = await _fileService.HandleFileRequestAsync(request ?? throw new NullReferenceException("No request data was sent"));
        return Ok();
    }

    // [HttpGet("enqueue")]
    // public IActionResult GetCurrentCopyJobs()   
    // {
    //     var result = _fileService.GetCurrentCopyJobs();
    //     return Ok(result);
    // }

    // [HttpGet("dequeue")]
    // public IActionResult DequeueItem()   
    // {
    //     var result = _fileService.Dequeue();
    //     return Ok(result);
    // }
}