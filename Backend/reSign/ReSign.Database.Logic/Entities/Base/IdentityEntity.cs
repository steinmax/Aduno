using System.ComponentModel.DataAnnotations;

namespace ReSign.Database.Logic.Entities.Base;
public abstract class IdentityEntity
{
    [Key]
    public int Id { get; set; }
}