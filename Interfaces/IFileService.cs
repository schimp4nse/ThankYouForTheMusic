using Models.Requests;

namespace Interfaces;

public interface IFileService
{
    /// <summary>
    ///     Add new copy job to cobyjob queue
    /// </summary>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    void AddCopyJob(string source, string destination);

    /// <summary>
    ///     Get overview of current unhandled copyjobs
    /// </summary>
    /// <returns></returns>
    object GetCurrentCopyJobs();

    /// <summary>
    ///     Get new item
    /// </summary>
    /// <returns></returns>
    object Dequeue();

    /// <summary>
    ///     Cancle copyjob by id
    /// </summary>
    /// <param name="itemId">Copyjob queue item id</param>
    /// <returns></returns>
    object CancleCopyJob(string itemId);

    /// <summary>
    ///     Handler for file requests
    /// </summary>
    /// <param name="request">Type = FileRequest</param>
    /// <returns></returns>
    Task<object> HandleFileRequestAsync(FileRequest request);
}