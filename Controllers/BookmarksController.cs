
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;

namespace Controllers;

public class BookmarkController : ControllerBase
{

    private readonly IBookmarkService _bookmarkService;

    public BookmarkController(IBookmarkService bookmerkService)
    {
        _bookmarkService = bookmerkService;
    } 

    [HttpPost("bookmarks/add")]
    public async Task<IActionResult> AddBookmark([FromBody] BaseRequest requestData)
    {
        await _bookmarkService.AddBookmarkAsync(requestData.Url ?? throw new Exception("Url is null or empty"));
        return Ok();
    }

    [HttpDelete("bookmarks/remove")]
    public async Task<IActionResult> RemoveBookmark([FromBody] BaseRequest requestData)
    {
        await _bookmarkService.DeleteBookmarkAsync(requestData.BookmarkId);
        return Ok();
    }

    [HttpGet("bookmarks")]
    public async Task<IActionResult> GetBookmarkList([FromRoute] string bookmarkId)
    {
        var result = await _bookmarkService.GetBookmarkAsync(bookmarkId);
        return Ok(result);
    }
}
