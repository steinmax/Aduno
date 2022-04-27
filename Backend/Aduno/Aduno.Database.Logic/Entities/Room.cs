using Aduno.Database.Logic.Entities.Base;
using Aduno.Database.Logic.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aduno.Database.Logic.Entities;

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
}
