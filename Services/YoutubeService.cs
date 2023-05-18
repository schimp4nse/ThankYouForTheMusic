using Interfaces;
using YoutubeExplode;

namespace Services;

public class YoutubeService : IYoutubeService
{
    /// <inheritdoc />
    public Task<object> HandleYoutubeRequestsAsync(string type, string url)
    {
        // TODO: Validate request
        switch (type)
        {
            case "download": { Download(url); } break;
            case "convertToMp4": { ConvertToMp4(url); } break;
            case "convertToMp3": { ConvertToMp3(url); } break;
            case "bookmark": { } break;
            default:
                {
                    throw new Exception("Downloadtype not implemented");
                };
        }

        return null;
    }

    /// <summary>
    ///     Downloads youtube movie and convers it into mp3
    /// </summary>
    /// <param name="url">Youtube link</param>
    private void ConvertToMp3(string url)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Downloads youtube movie and convers it into mp4
    /// </summary>
    /// <param name="url">Youtube link</param>
    private void ConvertToMp4(string url)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Downloads local youtube files
    /// </summary>
    /// <param name="url">Youtube link</param>
    private void Download(string url)
    {
        throw new NotImplementedException();
    }
}