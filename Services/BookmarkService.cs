using Database;
using Interfaces;
using Models.Responses;
using Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services;

// https://github.com/Tyrrrz/YoutubeExplode

public class BookmarkService : IBookmarkService
{

	private readonly DefaultDbContext _context;

	public BookmarkService(DefaultDbContext context)
	{
		_context = context;
	}


	/// <inheritdoc />
	public async Task AddBookmarkAsync(string url)
	{
		var bookmark = await _context.Bookmarks.FirstOrDefaultAsync(bm => bm.Url.Equals(url));
		if (bookmark is not null)
			throw new Exception("Bookmark with this url already exists");

		_context.Bookmarks.Add(new Bookmark { Url = url });
		await _context.SaveChangesAsync();
	}

	/// <inheritdoc />
	public async Task DeleteBookmarkAsync(long bookmarkId)
	{
		var bookmark =
			await _context.Bookmarks.FirstOrDefaultAsync(bm => bm.Id == bookmarkId)
			?? throw new Exception("Bookmark not found");

		var bm = _context.Bookmarks
		.FirstOrDefault(bm => bm.Id == bookmarkId)
		?? throw new Exception("Bookmark no found");

		_context.Bookmarks.Remove(bm);
		await _context.SaveChangesAsync();
	}

	/// <inheritdoc />
	public async Task<List<BookmarkResponse>> GetBookmarksAsync()
	{
		return await _context.Bookmarks
				.Select(bm =>
					new BookmarkResponse
					{
						BookmarkId = bm.Id,
						Url = bm.Url
					})
				.ToListAsync();
	}
}