using Aduno.Database.Logic.Entities.Base;
using Aduno.Database.Logic.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aduno.Database.Logic.Entities;

[Table("Interaction")]
public class Interaction : VersionEntity
{
    [Required]
    [Column(TypeName = "timestamp")]
    public DateTime DateTime { get; set; }
    [Required]
    public InteractionType Type { get; set; }

    //relations
    [Required]
    public int UserId { get; set; }
    [Required]
    public int RoomId { get; set; }

    //navigations
    public User? User { get; set; }
    public Room? Room { get; set; }
}
