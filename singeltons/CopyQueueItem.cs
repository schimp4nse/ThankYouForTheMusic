namespace Services;

public class CopyQueueItem
{
    public string source;
    public string destination;
    public Guid id; 

    public CopyQueueItem(Guid id, string source, string destination)
    {
        this.id = id;
        this.source = source;
        this.destination = destination;
    }
}