using Microsoft.EntityFrameworkCore;
using ReSign.Database.Logic.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSign.Database.Logic.Entities.General
{
    [Table("Organisation"), Index(nameof(Name), IsUnique = true)]
    public class Organisation : VersionObject
    {
        [Required()]
        public string Name { get; set; } = string.Empty;
    }
}
