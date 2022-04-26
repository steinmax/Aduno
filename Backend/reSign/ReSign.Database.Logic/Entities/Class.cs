using ReSign.Database.Logic.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ReSign.Database.Logic.Entities
{
    public class Class : VersionEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        //nav props
        public List<User> Users { get; set; } = new();
    }
}
