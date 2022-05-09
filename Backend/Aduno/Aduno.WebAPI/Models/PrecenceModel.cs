namespace Aduno.WebAPI.Models
{
    public class PrecenceModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool IsPresent { get; set; }
    }
}
