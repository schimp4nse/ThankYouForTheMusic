using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;

namespace Controllers;

[ApiController, Route("bookmarks")]
public class BookmarkController : ControllerBase
{

    private readonly IBookmarkService _bookmarkService;

    public BookmarkController(IBookmarkService bookmerkService)
    {
        _bookmarkService = bookmerkService;
    } 

    [HttpPost]
    public async Task<IActionResult> AddBookmark([FromBody] BaseRequest requestData)
    {
        await _bookmarkService.AddBookmarkAsync(requestData.Url ?? throw new Exception("Url is null or empty"));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBookmark([FromBody] BaseRequest requestData)
    {
        await _bookmarkService.DeleteBookmarkAsync(requestData.BookmarkId);
        return Ok();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetBookmarkList()
    {
        var result = await _bookmarkService.GetBookmarksAsync();
        return Ok(result);
    }
}
