using ReSign.Database.Data.Entities.Base;

namespace ReSign.Database.Data.Entities.General;

public class Room : VersionObject
{
    public char Floor { get; set; }
    public int RoomNumber { get; set; }
    public string? Notes { get; set; }
}
