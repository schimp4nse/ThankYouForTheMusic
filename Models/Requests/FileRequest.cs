namespace Models.Requests;

public class FileRequest {

    public string RequestType { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
}