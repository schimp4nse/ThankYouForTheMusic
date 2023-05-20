using Models.Responses;

namespace Interfaces;

public interface IPlaylistService
{
	/// <summary>
	/// 	Add new playlist entry
	/// </summary>
	/// <param name="playlistName">Name of new playlist</param>
	/// <returns></returns>
	Task<PlaylistResponse> AddPlaylistAsync(string playlistName);

	/// <summary>
	/// 	Get all available play lists
	/// </summary>
	/// <returns></returns>
	Task<List<PlaylistResponse>> GetAllPlaylistsAsync();

	/// <summary>
	/// 	Delete playlist by id
	/// </summary>
	/// <param name="playlistId">Playlist id</param>
	/// <returns></returns>
	Task DeletePlaylistAsync(long playlistId);
}