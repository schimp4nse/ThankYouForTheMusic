using Models.Responses;

namespace Interfaces;

public interface IBookmarkService {
		/// <summary>
		/// 	Add new Bookmark
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
    Task AddBookmarkAsync(string url);

		/// <summary>
		/// Delete bookmark by id
		/// </summary>
		/// <param name="bookmarkId"></param>
		/// <returns></returns>
    Task DeleteBookmarkAsync(long bookmarkId);

		/// <summary>
		/// 	Get all bookmarks
		/// </summary>
		/// <param name="bookmarkId"></param>
		/// <returns></returns>
    Task<List<BookmarkResponse>> GetBookmarksAsync();
}