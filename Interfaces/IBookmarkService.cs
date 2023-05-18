using Models.Responses;

namespace Interfaces;

public interface IBookmarkService {

    Task AddBookmarkAsync(string url);
    Task DeleteBookmarkAsync(long bookmarkId);

    Task<List<BookmarkResponse>> GetBookmarkAsync(string bookmarkId);
}