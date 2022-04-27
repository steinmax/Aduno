using Aduno.Database.Logic.Enumerations;

namespace Aduno.WebAPI.Models
{
    public class InteractionModel : IdentityModel
    {
        public DateTime DateTime { get; set; }
        public InteractionType Type { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int QRTokenId { get; set; }
    }
}
