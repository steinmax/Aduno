using ReSign.Database.Data.Entities.Base;
using ReSign.Database.Data.Entities.General;

namespace ReSign.Database.Data.Entities.PresenceSystem;
public class User : VersionObject
{
    public string MatNr { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    //References
    public int ClassId { get; set; }
    public int DeviceId { get; set; }

    //Navigation
    public Class Class { get; set; } = new();
    public Device Device { get; set; } = new();
}
