using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Request;

namespace Controllers;

public class YoutubeController : ControllerBase {
    
    private readonly IYoutubeService _youtubeService;
    public YoutubeController(IYoutubeService youtubeService)
    {
        _youtubeService = youtubeService;        
    }

    [HttpPost]
    public async Task<IActionResult> Post(YoutubeRequest request){
        var result = await _youtubeService.HandleYoutubeRequestsAsync(request.Type, request.Url);
        return Ok();
    }
}