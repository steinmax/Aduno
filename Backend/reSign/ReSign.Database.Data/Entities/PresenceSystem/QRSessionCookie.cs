using ReSign.Database.Data.Entities.Base;

namespace ReSign.Database.Data.Entities.PresenceSystem
{
    public class QRSessionCookie : VersionObject
    {
        public string Token { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool IsValid { get; set; }
    }
}
