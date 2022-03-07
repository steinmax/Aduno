using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReSign.Database.Logic.Entities.Base;

public class VersionEntity : IdentityEntity
{
    /*
    [ConcurrencyCheck]
    [Column("xmin", TypeName = "xid")]
    public long RowVersion { get; set; }
    */
}