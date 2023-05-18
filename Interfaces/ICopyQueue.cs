using Services;

namespace Interfaces;

public interface ICopyQueue
{
    List<CopyQueueItem> GetCurrentQueueStack() ;

    CopyQueueItem? Dequeue() ;
    
    void Enqueue(string source, string destination);
}