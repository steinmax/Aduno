using ReSign.Database.Data.Entities.Base;
using ReSign.Database.Data.Entities.PresenceSystem;

namespace ReSign.Database.Data.Entities.General;
public class Class : VersionObject
{
    public string Designation { get; set; }
    public int Grade { get; set; }
    public int RoomId { get; set; }

    //Navigation
    public List<Pupil> Pupils { get; set; } = new();
    public Room Room { get; set; }
}
