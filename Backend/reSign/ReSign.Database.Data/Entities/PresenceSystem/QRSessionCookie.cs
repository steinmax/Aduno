using ReSign.Database.Data.Entities.Base;
using ReSign.Database.Data.Entities.General;

namespace ReSign.Database.Data.Entities.PresenceSystem
{
    public class QRSessionCookie : VersionObject
    {
        public string Token { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool IsValid { get; set; }
        public int UsedByDeviceId { get; set; }
        public int DisplayId { get; set; }

     
        //navigation
        public Device? UsedByDevice { get; set; }
        public Display? Display { get; set; }
    }
}
