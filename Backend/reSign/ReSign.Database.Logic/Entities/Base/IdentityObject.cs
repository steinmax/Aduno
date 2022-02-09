using System.ComponentModel.DataAnnotations;

namespace ReSign.Database.Logic.Entities.Base;
public abstract class IdentityObject
{
    [Key]
    public int Id { get; set; }
}