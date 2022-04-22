using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Entities.General;
using ReSign.Database.Logic.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReSign.Database.Logic.Entities.PresenceSystem;

[Table("Interaction")]
public class Interaction : VersionEntity
{
    [Required]
    public DateTime DateTime { get; set; }
    [Required]
    public InteractionType Type { get; set; }

    //relations
    [Required]
    public int UserId { get; set; }
    [Required]
    public int RoomId { get; set; }
    [Required]
    public int QRTokenId { get; set; }

    //navigations
    public User? User { get; set; }
    public Room? Room { get; set; }
}
