namespace Interfaces;

public interface IYoutubeService
{
    /// <summary>
    ///     Handles all kind of downloads
    /// </summary>
    /// <param name="type"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    Task<object> HandleYoutubeRequestsAsync(string type, string url);
}