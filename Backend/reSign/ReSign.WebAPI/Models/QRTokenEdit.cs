namespace ReSign.WebAPI.Models
{
    public class QRTokenEdit
    {
        public string Token { get; set; } = string.Empty;
        public bool IsValid { get; set; } = true;

        public int? DeviceId { get; set; }
    }
}
