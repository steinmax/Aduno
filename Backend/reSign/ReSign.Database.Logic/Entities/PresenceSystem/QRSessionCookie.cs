using ReSign.Database.Logic.Entities.Base;
using ReSign.Database.Logic.Entities.General;

namespace ReSign.Database.Logic.Entities.PresenceSystem
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
