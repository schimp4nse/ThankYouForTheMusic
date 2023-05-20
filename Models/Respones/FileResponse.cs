namespace Models.Responses;

public class FileResponse {
    public long FileId { get; set; }
    public string FileName { get; set; }
    public string MimeType { get; set; }
    public string Url { get; set; }
    public DateTime CreationDate { get; set; }

}