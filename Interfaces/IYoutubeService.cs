namespace Interfaces;

public interface IYoutubeService
{
    Task<Models.Entities.File> Convert(string type, string url);

    FileStream Download(string url);
}