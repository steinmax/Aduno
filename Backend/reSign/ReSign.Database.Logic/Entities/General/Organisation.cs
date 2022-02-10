using Microsoft.EntityFrameworkCore;
using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Entities.PresenceSystem;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReSign.Database.Logic.Entities.General;

[Table("Organisation"), Index(nameof(Name), IsUnique = true)]
public class Organisation : VersionObject
{
    [Required]
    public string Name { get; set; } = string.Empty;

    //navigation
    public List<User> Users { get; set; } = new();
    public List<Room> Rooms { get; set; } = new();
}