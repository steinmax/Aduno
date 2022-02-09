

using ReSign.Database.Logic.Entities.Base;

namespace ReSign.Database.Logic.Entities.General;

public class Room : VersionObject
{
    public char Floor { get; set; }
    public int RoomNumber { get; set; }
    public string? Notes { get; set; }
}
