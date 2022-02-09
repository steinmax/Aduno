using ReSign.Database.Logic.Entities.Base;

namespace ReSign.Database.Logic.Entities.General;

public class Display : VersionObject
{
    public string MacAddress { get; set; } = string.Empty;
    public string? Designation { get; set; }
    public string? Notes { get; set; }

    //References
    public int RoomId { get; set; }

    //Navigation
    public Room Room { get; set; }
}