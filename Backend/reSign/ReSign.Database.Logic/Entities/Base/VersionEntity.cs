using System.ComponentModel.DataAnnotations;

namespace ReSign.Database.Logic.Entities.Base;

public class VersionEntity : IdentityEntity
{
    [Timestamp]
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}