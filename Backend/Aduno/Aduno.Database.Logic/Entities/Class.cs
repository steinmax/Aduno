using Aduno.Database.Logic.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aduno.Database.Logic.Entities
{
    [Table("Class")]
    [Index(nameof(Name), IsUnique = true)]
    public class Class : VersionEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        //nav props
        public List<User> Users { get; set; } = new();
    }
}
