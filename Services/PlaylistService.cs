using Database;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Responses;

namespace Services;

public class PlaylistService : IPlaylistService
{
	private readonly DefaultDbContext _context;

	public PlaylistService(DefaultDbContext context)
	{
		_context = context;
	}

	/// <inheritdoc />
	public async Task<PlaylistResponse> AddPlaylistAsync(string playlistName)
	{
		var playlist =
			await _context.PlayLists.FirstOrDefaultAsync(pl => pl.Name.Equals(playlistName));

		if (playlist is not null)
			throw new Exception($"Playlist with name '{playlistName}' already exists");

		var entity = _context.PlayLists.Add(new Models.Entities.PlayList { Name = playlistName }).Entity;
		await _context.SaveChangesAsync();

		return new PlaylistResponse
		{
			CreatedDate = entity.CreationDate,
			Name = entity.Name,
			PlaylistId = entity.PlaylistId,
		};
	}

	/// <inheritdoc />
	public async Task DeletePlaylistAsync(long playlistId)
	{
		var playlist =
			await _context.PlayLists.FirstOrDefaultAsync(pl => pl.PlaylistId == playlistId)
			?? throw new Exception($"Playlist with id {playlistId} not found");

		_context.PlayLists.Remove(playlist);
		await _context.SaveChangesAsync();
	}

	/// <inheritdoc />
	public async Task<List<PlaylistResponse>> GetAllPlaylistsAsync()
	{
		return await _context.PlayLists
					.Select(pl => new PlaylistResponse
					{
						CreatedDate = pl.CreationDate,
						Name = pl.Name,
						PlaylistId = pl.PlaylistId,
					})
					.ToListAsync();
	}

	private Task<PlaylistResponse> GetPlaylistByIdAsync(long playlistId)
	{
		throw new NotImplementedException();
	}
}