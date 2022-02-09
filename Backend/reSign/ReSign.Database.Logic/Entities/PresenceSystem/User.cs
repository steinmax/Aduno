using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Entities.General;

namespace ReSign.Database.Logic.Entities.PresenceSystem;
public class User : VersionObject
{
    public string MatNr { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    //References
    public int DeviceId { get; set; }

    //navigation
    public Device Device { get; set; } = new();
}
