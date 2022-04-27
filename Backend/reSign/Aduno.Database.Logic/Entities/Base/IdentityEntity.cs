using System.ComponentModel.DataAnnotations;

namespace Aduno.Database.Logic.Entities.Base;
public abstract class IdentityEntity
{
    [Key]
    public int Id { get; set; }
}