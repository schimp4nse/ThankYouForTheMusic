
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

[Table("Playlists")]
public class PlayList
{
    [Column(Order = 2)]
    public string Name { get; set; }

    [Required]
    [Column(Order = 3)]
    public DateTime CreationDate { get; set; } = DateTime.Now;

    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public long PlaylistId { get; set; }

    public virtual ICollection<Bookmark> Bookmarks { get; set; }
}