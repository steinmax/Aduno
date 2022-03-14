using ReSign.Database.Logic.Enumerations;

namespace ReSign.WebAPI.Models
{
    public class InteractionEdit
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int QRTokenId { get; set; }
    }
}
