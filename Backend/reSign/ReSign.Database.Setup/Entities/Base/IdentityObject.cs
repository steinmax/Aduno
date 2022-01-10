using System.ComponentModel.DataAnnotations;

namespace ReSign.Database.Logic.Entities;
public abstract class IdentityObject
{
    [Key]
    public int Id { get; set; }
}