using ReSign.Database.Logic.Enumerations;

namespace ReSign.WebAPI.Models
{
    public class RoomModel : IdentityModel
    {
        public string Designation { get; set; } = string.Empty;
        public Floor Floor { get; set; }
        public int RoomNumber { get; set; }
        public string? Notes { get; set; }
        public int OranisationId { get; set; }
    }
}
