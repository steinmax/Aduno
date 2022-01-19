using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Entities.PresenceSystem;

namespace ReSign.Database.Logic.Entities.General;
public class Class : VersionObject
{
    public string Designation { get; set; }
    public int Grade { get; set; }
    public int RoomId { get; set; }

    //Navigation
    public List<Pupil> Pupils { get; set; } = new();
    public Room Room { get; set; }
}
