using System.Collections.Concurrent;
using Interfaces;

namespace Services;

public class CopyQueue : ICopyQueue
{
    // private static readonly object _codeLock = new object();
    // private static readonly Lazy<CopyQueue> lazy = new Lazy<CopyQueue>(() => new CopyQueue());
    // private static CopyQueue Instance = lazy.Value;
    
    private ConcurrentQueue<CopyQueueItem> _data;

    public CopyQueue()
    {
        _data = new ConcurrentQueue<CopyQueueItem>();
    }

    public List<CopyQueueItem> GetCurrentQueueStack() => _data.ToList();

    public void Enqueue(string source, string destination) => _data.Enqueue(new CopyQueueItem(Guid.NewGuid(), source, destination));

    public CopyQueueItem Dequeue()
    {
        CopyQueueItem? item = null;
        _data.TryDequeue(out item);
        return item;
    }
}