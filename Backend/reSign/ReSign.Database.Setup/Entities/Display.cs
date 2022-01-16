using ReSign.Database.Logic.Entities.Base;

namespace ReSign.Database.Logic.Entities;

public class Display : VersionObject
{
    public string MacAddress { get; set; } = string.Empty;
    public string? Designation { get; set; }
    public string? Notes { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; }
}