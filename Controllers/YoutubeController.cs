using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;

namespace Controllers;

[ApiController, Route("youtube")]
public class YoutubeController: ControllerBase
{
    private readonly IYoutubeService _youtubeService;
    public YoutubeController(IYoutubeService youtubeService)
    {
        _youtubeService = youtubeService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(YoutubeRequest request)
    {
        FileStream fileStream = null;
        // TODO: Validate request
        switch (request.Type)
        {
            case "download": { fileStream = _youtubeService.Download(request.Url); } break;
            case "convertToMp4": { await _youtubeService.Convert("mp4", request.Url); } break;
            case "convertToMp3": { await _youtubeService.Convert("mp3", request.Url); } break;
            case "search": { throw new NotImplementedException(); } break;
            default: { throw new Exception("Type not implemented"); };
        }

        // Return file
        if (request.Type.Equals("download")) { return File(fileStream ?? throw new Exception("Error: fileStream is null"), ""); };

        // Return information
        return Ok();
    }
}