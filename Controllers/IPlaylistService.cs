using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;

namespace Controller;

[Controller, Route("playlist")]
public class PlayListController : ControllerBase
{
	private readonly IPlaylistService _playlist;

	public PlayListController(IPlaylistService playlist)
	{
		_playlist = playlist;
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] PlaylistRequest request)
	{
		var result = await _playlist.AddPlaylistAsync(request.Name);
		return Ok();
	}

	[HttpDelete("/{playlistId}")]
	public async Task<IActionResult> Delete([FromBody] long playlistId)
	{
		await _playlist.DeletePlaylistAsync(playlistId);
		return Ok();
	}
}