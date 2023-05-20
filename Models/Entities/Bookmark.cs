using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

[Table("Bookmarks")]
public class Bookmark
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public long Id { get; set; }

    [Required]
    [Column(Order = 2)]
    public string Url { get; set; } = string.Empty;

    [Column(Order = 3)]
    public virtual ICollection<File>? Files { get; set; }
}