using Database;
using Interfaces;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Services;

// https://github.com/Tyrrrz/YoutubeExplode

public class YoutubeService : IYoutubeService
{
    private readonly DefaultDbContext _context;

    public YoutubeService(DefaultDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Downloads youtube movie and convers it into mp3
    /// </summary>
    /// <param name="url">Youtube link</param>
    public async Task<Models.Entities.File> Convert(string type, string url)
    {
        // TODO: Add files to Bookmark
        // ** Add bookmarkId and link file to bookmark

        // TODO: Add to environment
        var downloadFolder = @"E:\ThankYouForTheMusic";

        // Init youtube data
        // ** Generate client
        var youtube = new YoutubeClient();
        // ** Get video metadata
        var video = await youtube.Videos.GetAsync(url);
        // ** Get available stream (quality and types)
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);

        // Generate entity
        var dbFile = new Models.Entities.File()
        {
            FileName = $"{video.Title}",
            FilePath = $"{downloadFolder}\\{video.Title}.{type}",
            Duration = video.Duration ?? new TimeSpan(),
            MimeType = $"{(type.Equals("mp4") ? "video/mp4" : "audio/mpeg")}",
            Url = url
        };

        // prechecks
        if (_context.Files.FirstOrDefault(f => f.FilePath.Equals(dbFile.FilePath)) != null)
            throw new Exception("File already exists at directory");

        // Choose Stream info type
        var streamInfo = type switch
        {
            "mp4" => streamManifest.GetMuxedStreams().GetWithHighestVideoQuality(),
            "mp3" => streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate(),
            _ => throw new Exception("Type not implemented")
        };

        try
        {
            // TODO: Error when emoji in name
            IProgress<double> progress = new Progress<double>();
            // Download
            await youtube.Videos.Streams.DownloadAsync(streamInfo, dbFile.FilePath, progress);

            // TODO: implement signalR for download progress
        }
        catch (System.Exception ex)
        {
            throw new Exception("Download failed", ex);
        }

        var entity = _context.Files.AddAsync(dbFile).Result.Entity;
        await _context.SaveChangesAsync();

        // TODO: Logging

        return entity;
    }

    /// <summary>
    ///     Downloads local youtube files
    /// </summary>
    /// <param name="url">Youtube link</param>
    public FileStream Download(string url)
    {
        throw new NotImplementedException();
    }
}

// ...or highest quality MP4 video-only stream
// var streamInfo = streamManifest
//     .GetVideoOnlyStreams()
//     .Where(s => s.Container == Container.Mp4)
//     .GetWithHighestVideoQuality();