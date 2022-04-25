using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReSign.Database.Logic.Entities;

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
    public int ClassId { get; set; }

    [Required]
    public Role Role { get; set; } = Role.Member;

    //nav
    public Class? Class { get; set; }
}
