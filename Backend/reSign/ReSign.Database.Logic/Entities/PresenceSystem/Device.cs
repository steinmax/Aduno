using Microsoft.EntityFrameworkCore;
using ReSign.Database.Logic.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReSign.Database.Logic.Entities.PresenceSystem;

[Table("Device"), Index(nameof(UniqueId), IsUnique = true)]
public class Device : VersionObject
{
    [Required]
    public string UniqueId { get; set; } = string.Empty; //Could be AndroidId, IMEI or something else

    //reference
    [Required]
    public int UserId { get; set; }

    //navigation
    public User? User { get; set; }
}
