using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReSign.Database.Logic.Entities.General;

[Table("Room")]
public class Room : VersionEntity
{
    [Required]
    public string Designation { get; set; } = string.Empty;

    [Required]
    public Floor Floor { get; set; }
    [Required]
    public int RoomNumber { get; set; }

    public string? Notes { get; set; }

    //relations
    [Required]
    public int OrganisationId { get; set; }

    //navigation
    public Organisation? Organisation { get; set; }
}
