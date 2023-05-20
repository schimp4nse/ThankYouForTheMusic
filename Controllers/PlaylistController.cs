using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[Controller, Route("playlist")]
public class PlayListController: ControllerBase {

    // public PlaylistController(){}

    [HttpPost]
    public async Task<IActionResult> Post(){
        return Ok();
    }
}