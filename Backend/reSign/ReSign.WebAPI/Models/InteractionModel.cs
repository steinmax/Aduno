using ReSign.Database.Logic.Enumerations;

namespace ReSign.WebAPI.Models
{
    public class InteractionModel : IdentityModel
    {
        public DateTime DateTime { get; set; }
        public InteractionType Type { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
    }
}
