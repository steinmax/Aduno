using ReSign.Database.Logic.Entities.Base;

namespace ReSign.Database.Logic.Entities.PresenceSystem;
public class Device : VersionObject
{
    public string UniqueId { get; set; } = string.Empty; //Could be AndroidId, IMEI or something else
}
