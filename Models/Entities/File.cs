using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

[Table("Files")]
public class File
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public long FileId { get; set; }

    [Column(Order = 2)]
    public string FileName { get; set; } = string.Empty;

    [Column(Order = 3)]
    public TimeSpan? Duration { get; set; }

    [Column(Order = 4)]
    public string MimeType { get; set; } = string.Empty;

    [Column(Order = 5)]
    public string FilePath { get; set; } = string.Empty;

    [Column(Order = 6)]
    public string Url { get; set; } = string.Empty;

    [Column(Order = 7)]
    public DateTime CreationDate { get; set; } = DateTime.Now;

    // Navigation properties
    // [ForeignKey("Playlist_FK")]
    // [Column(Order = 8)]
    // public PlayList PlayList { get; set; }
}