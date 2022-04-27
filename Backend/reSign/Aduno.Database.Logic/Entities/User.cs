using Aduno.Database.Logic.Entities.Base;
using Aduno.Database.Logic.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aduno.Database.Logic.Entities;

[Table("User"), Index(nameof(FirstName), nameof(LastName)), Index(nameof(Username), IsUnique = true)]
public class User : VersionEntity
{
    [Required, MaxLength(128)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(128)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string Username { get; internal set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public DateTime CreationDate { get; internal set; }

    [Required]
    public Role Role { get; set; } = Role.Member;

    //references
    [Required]
    public int ClassId { get; set; }

    //nav
    public Class? Class { get; set; }
}
