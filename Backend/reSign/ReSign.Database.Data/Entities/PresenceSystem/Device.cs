using ReSign.Database.Data.Entities.Base;

namespace ReSign.Database.Data.Entities.PresenceSystem;
public class Device : VersionObject
{
    public string UniqueId { get; set; } = string.Empty; //Could be AndroidId, IMEI or something else
}
