
using Database;
using Interfaces;
using Models.Responses;
using Models.Entities;
using YoutubeExplode;
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


    public async Task AddBookmarkAsync(string url)
    {
        _context.Bookmarks.Add(new Bookmark { Url = url });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookmarkAsync(long bookmarkId)
    {
        var bm = _context.Bookmarks
        .FirstOrDefault(bm => bm.Id == bookmarkId)
        ?? throw new Exception("Bookmark no found");

        _context.Bookmarks.Remove(bm);
        await _context.SaveChangesAsync();
    }

    public Task<object> DownloadAsync(string url)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BookmarkResponse>> GetBookmarkAsync(string bookmarkId)
    {
        var result = new List<BookmarkResponse>();
        await _context.Bookmarks
            .ForEachAsync(bm =>
            {
                result.Add(
                new BookmarkResponse
                {
                    BookmarkId = bm.Id,
                    Url = bm.Url
                });
            });
            
        return result;
    }
}