namespace ReSign.WebAPI.Models
{
    public class QRTokenModel : IdentityModel
    {
        public string Token { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsValid { get; set; } = true;

        public int? DeviceId { get; set; }
    }
}
