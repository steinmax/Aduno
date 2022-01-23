using System.ComponentModel.DataAnnotations;

namespace ReSign.Database.Data.Entities.Base;

public class VersionObject : IdentityObject
{
    [Timestamp]
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}