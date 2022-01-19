using ReSign.Database.Logic.Entities.Base;

namespace ReSign.Database.Logic.Entities.PresenceSystem
{
    public class QRSessionCookie : VersionObject
    {
        public string Token { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool IsValid { get; set; }
    }
}
