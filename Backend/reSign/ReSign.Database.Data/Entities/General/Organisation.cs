using ReSign.Database.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSign.Database.Data.Entities.General
{
    [Table(), Index()]
    public class Organisation : VersionObject
    {
        [Required()]
        public string Name { get; set; } = string.Empty;
    }
}
