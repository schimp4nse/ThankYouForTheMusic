using Interfaces;
using Models.Requests;

namespace Services;

public class FileService : IFileService
{
    public readonly ICopyQueue _copyQueue;
    public FileService(ICopyQueue copyQueue)
    {
        _copyQueue = copyQueue;
    }

    /// <inheritdoc />
    public void AddCopyJob(string source, string destination)
    {
        _copyQueue.Enqueue(source, destination);
    }

    /// <inheritdoc />
    public object CancleCopyJob(string itemId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public object Dequeue()
    {
        var item = _copyQueue.Dequeue();

        if (item is null)
            return new { errorMessage = "Queue is null" };

        return new { id = item.id, source = item.source, destination = item.destination };
    }

    /// <inheritdoc />
    public object GetCurrentCopyJobs()
    {
        var response = _copyQueue.GetCurrentQueueStack()
            .Select(item => new { id = item.id, source = item.source, destination = item.destination });
        return response;
    }

    /// <inheritdoc />
    public async Task<object> HandleFileRequestAsync(FileRequest request)
    {
        // TODO: Validate request
        switch (request.RequestType)
        {
            case "move":
                {
                    MoveFileAsync(request.Source, request.Destination);
                }
                break;

            case "copy":
                {
                    CopyFile(request.Source, request.Destination);
                }
                break;
            case "download":
                {
                    DownloadFileAsync(request.Source);
                }
                break;

            default:
                {
                    // TODO: Logging
                    throw new Exception("RequestType not implemented");
                };
        }

        // TODO: Logging

        return null;
    }

    /// <summary>
    ///     File download
    /// </summary>
    /// <param name="source">File source destination</param>
    private object DownloadFileAsync(string source)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     File copy 
    /// </summary>
    /// <param name="source">File source source</param>
    /// <param name="destination">>File source destination</param>
    private void CopyFile(string source, string destination)
    {
        try
        {
            var errorMessage = "";

            // Prechecks
            if (!File.Exists(source)) { errorMessage += "Sourcefile does not exists\n"; }
            if (File.Exists(destination)) { errorMessage += ", File already exists\n"; }
            if (!string.IsNullOrEmpty(errorMessage)) { throw new Exception(errorMessage); }

            // Copy and delete
            File.Copy(source, destination);
        }
        catch (System.Exception) { throw; }
    }

    /// <summary>
    ///     File move
    /// </summary>
    /// <param name="source">File source source</param>
    /// <param name="destination">>File source destination</param>
    private void MoveFileAsync(string source, string destination)
    {
        try
        {
            var errorMessage = "";

            // Prechecks
            if (!File.Exists(source)) { errorMessage += "Sourcefile does not exists\n"; }
            if (File.Exists(destination)) { errorMessage += ", File already exists\n"; }
            if (!string.IsNullOrEmpty(errorMessage)) { throw new Exception(errorMessage); }

            // Copy and delete
            File.Copy(source, destination);
            File.Delete(source);
        }
        catch (System.Exception) { throw; }
    }

    /// <inheritdoc />
    public Task<object> HandleYoutubeRequestsAsync(string type, string url)
    {
        // TODO: Validate request
        switch (type)
        {
            case "download": { } break;
            case "convertToMp4": { } break;
            case "convertToMp3": { } break;
            case "bookmark": { } break;
            default:
                {
                    throw new Exception("Downloadtype not implemented");
                };
        }

        return null;
    }
}