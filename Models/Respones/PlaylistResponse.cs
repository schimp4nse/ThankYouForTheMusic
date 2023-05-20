namespace Models.Responses;

public class PlaylistResponse
{
    public long PlaylistId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }

    List<FileResponse> Files { get; set; }
}